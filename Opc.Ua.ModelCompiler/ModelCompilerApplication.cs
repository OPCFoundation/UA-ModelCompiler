using McMaster.Extensions.CommandLineUtils;
using Newtonsoft.Json;
using Opc.Ua;
using System.Reflection;

namespace ModelCompiler
{
    static class ModelCompilerApplication
    {
        public static void Run(string[] args)
        {
            Utils.SetTraceMask(Utils.TraceMasks.Error);
            Utils.SetTraceOutput(Utils.TraceOutput.DebugAndFile);

            var app = new CommandLineApplication();
            app.Name = "ModelCompiler";
            app.Description = "An application takes an OPC UA model file and generates code for the .NETStandard stack.";
            app.HelpOption("-?|-h|--help");

            app.Command("compile", (e) => Compile(e));
            app.Command("units", (e) => Units(e));
            app.Command("update-headers", (e) => UpdateHeaders(e));
            app.Command("compile-nodesets", (e) => CompileNodeSets(e));

            app.OnExecute(() =>
            {
                app.ShowHelp();
                return 0;
            });

            app.Execute(args);
        }

        private static void WriteLine(string message, ConsoleColor color)
        {
            var current = System.Console.ForegroundColor;
            System.Console.ForegroundColor = color;
            System.Console.WriteLine(message);
            System.Console.ForegroundColor = current;
        }

        public class NodeSetInfo
        {
            public string FileName { get; set; }
            public string ModelUri { get; set; }
            public string Name { get; set; }
            public string Prefix { get; set; }
            public bool Ignore { get; set; }
            public string Version { get; set; }

            [JsonIgnore]
            public Opc.Ua.Export.UANodeSet NodeSet { get; set; }

            [JsonIgnore]
            public List<NodeSetInfo> PreviousVersions { get; set; }
        }

        public class NodeSetFile
        {
            public List<NodeSetInfo> NodeSets { get; set; }
        }

        private static string GetNameFromUri(string uri)
        {
            var builder = new Uri(uri);
            var path = builder.LocalPath.TrimEnd('/');

            if (path.StartsWith("/UA/"))
            {
                path = path.Substring(4);
            }

            if (path.StartsWith("/OpcUa/"))
            {
                path = path.Substring(7);
            }

            return path.Trim('/').Replace("/", "").Replace('-', '_').Replace('+', '_');
        }

        private static void LoadNodeSet(FileInfo file, Dictionary<string, NodeSetInfo> nodesets)
        {
            try
            {
                if (!NodeSetToModelDesign.IsNodeSet(file.FullName))
                {
                    return;
                }

                using (var istrm = file.OpenRead())
                {
                    SystemContext context = new SystemContext();
                    Opc.Ua.Export.UANodeSet nodeset = Opc.Ua.Export.UANodeSet.Read(istrm);

                    context.NamespaceUris = new NamespaceTable();

                    if (nodeset.NamespaceUris != null)
                    {
                        foreach (var item in nodeset.NamespaceUris)
                        {
                            context.NamespaceUris.GetIndexOrAppend(item);
                        }
                    }

                    context.ServerUris = new StringTable();

                    if (nodeset.ServerUris != null)
                    {
                        foreach (var item in nodeset.ServerUris)
                        {
                            context.ServerUris.GetIndexOrAppend(item);
                        }
                    }

                    var collection = new NodeStateCollection();
                    
                    try
                    {
                        nodeset.Import(context, collection);
                    }
                    catch (Exception e)
                    {
                        WriteLine($"NodeSet could not be loaded ({file.FullName}): {e.Message}", ConsoleColor.Red);
                        return;
                    }

                    if (nodeset.Models == null || nodeset.Models.Length == 0 || String.IsNullOrEmpty(nodeset.Models[0].ModelUri))
                    {
                        WriteLine($"NodeSet is missing model definition ({file.FullName}).", ConsoleColor.Red);
                        return;
                    }

                    var model = nodeset.Models[0];

                    if (!Uri.IsWellFormedUriString(model.ModelUri, UriKind.Absolute))
                    {
                        WriteLine($"NodeSet ModelURI is not valid ({model.ModelUri}).", ConsoleColor.Red);
                        return;
                    }

                    var name = GetNameFromUri(model.ModelUri);

                    var info = new NodeSetInfo()
                    {
                        FileName = file.FullName,
                        ModelUri = model.ModelUri,
                        Version = model.PublicationDate.ToString("yyyy-MM-dd"),
                        Name = name,
                        Prefix = "UAModel." + name,
                        Ignore = false,
                        NodeSet = nodeset
                    };

                    if (nodesets.TryGetValue(model.ModelUri, out var existing))
                    {
                        if (existing.Version.CompareTo(info.Version) < 0)
                        {
                            info.PreviousVersions = new List<NodeSetInfo>();

                            if (existing.PreviousVersions != null)
                            {
                                info.PreviousVersions.AddRange(existing.PreviousVersions);
                            }

                            existing.PreviousVersions = null;
                            info.PreviousVersions.Add(existing);
                        }
                    }

                    nodesets[model.ModelUri] = info;
                    // WriteLine($"NodeSet ({model.ModelUri}) found.", ConsoleColor.Cyan);
                }
            }
            catch (Exception e)
            {
                WriteLine($"Could not parse NodeSet ({file.Name}): {e.Message}.", ConsoleColor.Red);
            }
        }

        private static NodeSetFile LoadConfigFile(DirectoryInfo directory)
        {
            var path = Path.Combine(directory.FullName, ".modelcompiler.json");

            NodeSetFile config = null;

            if (File.Exists(path))
            {
                using (var reader = new StreamReader(path))
                {
                    config = JsonConvert.DeserializeObject<NodeSetFile>(reader.ReadToEnd());
                }
            }

            return config;
        }

        private static void ApplyConfigFile(DirectoryInfo directory, NodeSetFile config, Dictionary<string, NodeSetInfo> nodesets)
        {
            if (config?.NodeSets != null)
            {
                foreach (var nodeset in config.NodeSets)
                {
                    if (String.IsNullOrEmpty(nodeset.ModelUri))
                    {
                        continue;
                    }

                    if (nodesets.TryGetValue(nodeset.ModelUri, out var existing))
                    {
                        if (existing.FileName == null || ComparePaths(Path.GetDirectoryName(existing.FileName), directory.FullName))
                        {
                            existing.Name = nodeset.Name;
                            existing.Prefix = nodeset.Prefix;
                            existing.Ignore = nodeset.Ignore;
                        }
                    }
                }
            }
        }

        private static bool ComparePaths(string path1, string path2)
        {
            if (path1 == null || path2 == null)
            {
                return false;
            }

            var a = new FileInfo(".\\" + path1).FullName.ToUpperInvariant().Trim(new char[] { '\\', '/' });
            var b = new FileInfo(path2).FullName.ToUpperInvariant().Trim(new char[] { '\\', '/' });

            return a == b;
        }

        private static void CollectNodeSets(DirectoryInfo directory, Dictionary<string, NodeSetInfo> nodesets)
        {
            var config = LoadConfigFile(directory);

            foreach (var file in directory.GetFiles("*.xml"))
            {
                if (config != null && config.NodeSets.Where(x => ComparePaths(x.FileName, file.Name) && x.Ignore).Any())
                {
                    continue;
                }

                LoadNodeSet(file, nodesets);
            }

            ApplyConfigFile(directory, config, nodesets);

            foreach (var child in directory.GetDirectories())
            {
                CollectNodeSets(child, nodesets);
            }
        }

        private static bool CollectDependencies(NodeSetInfo target, Dictionary<string, NodeSetInfo> nodesets, Dictionary<string, NodeSetInfo> dependencies)
        {
            if (target.NodeSet.NamespaceUris == null)
            {
                return true;
            }

            foreach (var ns in target.NodeSet.NamespaceUris)
            {
                if (dependencies.ContainsKey(ns) || ns == target.ModelUri)
                {
                    continue;
                }

                if (!nodesets.TryGetValue(ns, out NodeSetInfo nodeset))
                {
                    WriteLine($"NodeSet ({target.ModelUri}) dependency is missing ({ns}).", ConsoleColor.Red);
                    return false;
                }

                dependencies[ns] = nodeset;

                if (!CollectDependencies(nodeset, nodesets, dependencies))
                {
                    return false;
                }
            }

            return true;
        }

        private static void GenerateCode(
            string inputPath,
            string outputPath,
            Dictionary<string, NodeSetInfo> nodesets,
            NodeSetInfo nodeset,
            Dictionary<string, NodeSetInfo> dependecies)
        {
            ModelGenerator2 generator = new ModelGenerator2();
            
            generator.AvailableNodeSets = new Dictionary<string,string>(
                nodesets.
                Select(x => new KeyValuePair<string,string>(x.Key, x.Value.FileName)
            ));

            generator.LogMessage += (e) =>
            {
                WriteLine(e.Message, (e.Severity > 0) ? ConsoleColor.Red : ConsoleColor.Yellow);
                return Task.CompletedTask;
            };

            List<string> files = new List<string>();
            files.Add($"{nodeset.FileName},{nodeset.Prefix},{nodeset.Name}");

            foreach (var dependency in dependecies.Values.Where(x => x.ModelUri != Namespaces.OpcUa))
            {
                files.Add($"{dependency.FileName},{dependency.Prefix},{dependency.Name}");
            }

            string[] exclusions = new string[] { "Draft" };

            generator.ValidateAndUpdateIds(
                files.ToArray(),
                null,
                0,
                "v105",
                true,
                exclusions,
                null,
                null,
                true,
                false);

            WriteLine($"NodeSet ({nodeset.ModelUri}) loaded.", ConsoleColor.DarkYellow);

            var relativePath = new FileInfo(nodeset.FileName).DirectoryName.Substring(new DirectoryInfo(inputPath).FullName.Length);

            var output = Path.Join(outputPath, relativePath);

            if (!Directory.Exists(output))
            {
                Directory.CreateDirectory(output);
            }

            var documentation = new FileInfo(nodeset.FileName.Replace(".xml", ".documentation.csv"));

            if (documentation.Exists)
            {
                documentation.CopyTo(Path.Join(output, $"{nodeset.Prefix}.NodeSet2.documentation.csv"));
            }

            generator.GenerateMultipleFiles(output, false, exclusions, false);

            WriteLine($"NodeSet ({nodeset.ModelUri}) code generated ({output}).", ConsoleColor.DarkGreen);
        }

        private static void CompileNodeSets(CommandLineApplication app)
        {
            app.Description = "Searches a directory tree for nodesets and generates code for the specified model URIs.";
            app.HelpOption("-?|-h|--help"); 
            
            app.Option(
                $"-{OptionsNames.InputPath}",
                "The path to the directory containing the nodesets.",
                CommandOptionType.SingleValue);

            app.Option(
                $"-{OptionsNames.OutputPath}",
                "The path to the directory to use to write the generated files.",
                CommandOptionType.SingleValue);

            app.Option(
                $"-{OptionsNames.OutputPrefix}",
                "The prefix on generated files.",
                CommandOptionType.SingleValue);

            app.Option(
                $"-{OptionsNames.ModelUris}",
                "The URI of the model to generate.",
                CommandOptionType.MultipleValue);

            app.OnExecute(() =>
            {
                var options = GetCompileOptions(app);

                var input = new DirectoryInfo(options.InputPath);

                if (!input.Exists)
                {
                    throw new ArgumentException($"The input directory does not exist ({options.InputPath}).");
                }

                Dictionary<string, NodeSetInfo> nodesets = new();
                CollectNodeSets(input, nodesets);
                WriteLine($"{nodesets.Count} NodeSets found.", ConsoleColor.Cyan);
                WriteLine($"Writing output to {options.OutputPath}", ConsoleColor.Cyan);

                HashSet<string> found = new();

                foreach (var modelUri in options.ModelUris)
                {
                    if (!nodesets.TryGetValue(modelUri, out NodeSetInfo nodeset))
                    {
                        continue;
                    }

                    var relativePath = new FileInfo(nodeset.FileName).DirectoryName.Substring(new DirectoryInfo(input.FullName).FullName.Length);

                    var output = Path.Join(options.OutputPath, relativePath);

                    if (Directory.Exists(output))
                    {
                        Directory.Delete(output, true);
                    }
                }
                 
                foreach (var modelUri in options.ModelUris)
                {
                    if (!nodesets.TryGetValue(modelUri, out NodeSetInfo nodeset))
                    {
                        continue;
                    }

                    found.Add(modelUri);

                    Dictionary<string, NodeSetInfo> dependencies = new();
                    
                    if (!CollectDependencies(nodeset, nodesets, dependencies))
                    {
                        continue;
                    }

                    WriteLine($"NodeSet ({nodeset.ModelUri}) dependencies found.", ConsoleColor.DarkYellow);

                    if (!String.IsNullOrEmpty(options.OutputPrefix))
                    {
                        nodeset.Prefix = options.OutputPrefix;
                    }

                    try
                    {
                        GenerateCode(input.FullName, options.OutputPath, nodesets, nodeset, dependencies);
                    }
                    catch (Exception e)
                    {
                        WriteLine($"NodeSet ({nodeset.ModelUri}) code generation failed: {e.Message}", ConsoleColor.Red);
                    }
                }

                foreach (var uri in options.ModelUris)
                {
                    if (!found.Contains(uri))
                    {
                        WriteLine($"NodeSet ({uri}) not found!", ConsoleColor.Red);
                    }
                }

                return 0;
            });
        }

        private static void Compile(CommandLineApplication app)
        {
            app.Description = "Takes an OPC UA ModelDesign file and generates a NodeSet and code for the .NETStandard stack.";
            app.HelpOption("-?|-h|--help");
            AddCompileOptions(app);

            app.OnExecute(() =>
            {
                var options = GetCompileOptions(app);

                ModelGenerator2 generator = new ModelGenerator2();

                generator.LogMessage += (e) =>
                {
                    WriteLine(e.Message, (e.Severity > 0) ? ConsoleColor.Red : ConsoleColor.Yellow);
                    return Task.CompletedTask;
                };

                for (int ii = 0; ii < options.DesignFiles.Count; ii++)
                {
                    if (String.IsNullOrEmpty(options.DesignFiles[ii]))
                    {
                        throw new ArgumentException("No design file specified.");
                    }

                    var file = options.DesignFiles[ii].Split(',');

                    if (!new FileInfo(file[0]).Exists)
                    {
                        throw new ArgumentException("The design file does not exist: " + options.DesignFiles[ii]);
                    }
                }

                if (String.IsNullOrEmpty(options.IdentifierFile))
                {
                    // throw new ArgumentException("No identifier file specified.");
                }

                else if (!new FileInfo(options.IdentifierFile).Exists)
                {
                    if (!options.CreateIdentifierFile)
                    {
                        throw new ArgumentException("The identifier file does not exist: " + options.IdentifierFile);
                    }

                    File.Create(options.IdentifierFile).Close();
                }

                generator.ValidateAndUpdateIds(
                    options.DesignFiles,
                    options.IdentifierFile,
                    options.StartId,
                    options.Version,
                    options.UseAllowSubtypes,
                    options.Exclusions,
                    options.ModelVersion,
                    options.ModelPublicationDate,
                    options.ReleaseCandidate,
                    false);

                if (!String.IsNullOrEmpty(options.DotNetStackPath))
                {
                    if (!new DirectoryInfo(options.DotNetStackPath).Exists)
                    {
                        throw new ArgumentException("The directory does not exist: " + options.DotNetStackPath);
                    }

                    StackGenerator.GenerateDotNet(
                        options.DesignFiles, 
                        options.IdentifierFile,
                        options.DotNetStackPath, 
                        options.Version,
                        options.Exclusions);
                }

                if (!String.IsNullOrEmpty(options.AnsiCStackPath))
                {
                    if (!new DirectoryInfo(options.AnsiCStackPath).Exists)
                    {
                        throw new ArgumentException("The directory does not exist: " + options.AnsiCStackPath);
                    }

                    StackGenerator.GenerateAnsiC(
                        options.DesignFiles, 
                        options.IdentifierFile, 
                        options.AnsiCStackPath, 
                        options.Version,
                        options.Exclusions);

                    generator.GenerateIdentifiersAndNamesForAnsiC(options.AnsiCStackPath, options.Exclusions);
                }

                if (!String.IsNullOrEmpty(options.OutputPath))
                {
                    if (!Directory.Exists(options.OutputPath))
                    {
                        Directory.CreateDirectory(options.OutputPath);
                    }

                    generator.GenerateMultipleFiles(options.OutputPath, false, options.Exclusions, false);
                }

                return 0;
            });
        }

        private static void Units(CommandLineApplication app)
        {
            app.Description = "Generates the OPC UA Engineering Units CSV from the official UNECE table of units.";
            app.HelpOption("-?|-h|--help");
            AddUnitsOptions(app);

            app.OnExecute(() =>
            {
                var options = GetUnitsOptions(app);
                MeasurementUnits.Process(options.Annex1Path, options.Annex2Path, options.OutputPath);
                return 0;
            });
        }

        private static void UpdateHeaders(CommandLineApplication app)
        {
            app.Description = "Updates all files in the output directory with the OPC Foundation MIT license header.";
            app.HelpOption("-?|-h|--help");
            AddUpdateHeadersOptions(app);

            app.OnExecute(() =>
            {
                var options = GetUpdateHeadersOptions(app);
                HeaderUpdateTool.ProcessDirectory(options.InputPath, options.FilePattern, options.LicenseType, options.Silent);
                return 0;
            });
        }

        private static class OptionsNames
        {
            public const string DesignFiles = "d2";
            public const string IdentifierFile = "c";
            public const string GenerateIdentifierFile = "cg";
            public const string OutputPath = "o2";
            public const string Version = "version";
            public const string AnsiCStackPath = "ansic";
            public const string DotNetStackPath = "stack";
            public const string UseAllowSubtypes = "useAllowSubtypes";
            public const string StartId = "id";
            public const string Exclusions = "exclude";
            public const string InputPath = "input";
            public const string FilePattern = "pattern";
            public const string LicenseType = "license";
            public const string Silent = "silent";
            public const string Annex1Path = "annex1";
            public const string Annex2Path = "annex2";
            public const string UnitsOutputPath = "output";
            public const string ModelVersion = "mv";
            public const string ModelPublicationDate = "pd";
            public const string ReleaseCandidate = "rc";
            public const string ModelUris = "uri";
            public const string OutputPrefix = "prefix";
        }

        private class OptionValues
        {
            public IList<string> DesignFiles;
            public string IdentifierFile;
            public bool CreateIdentifierFile;
            public string OutputPath;
            public string DotNetStackPath;
            public string AnsiCStackPath;
            public string Version;
            public bool UseAllowSubtypes;
            public uint StartId;
            public IList<string> Exclusions;
            public string ModelVersion;
            public string ModelPublicationDate;
            public bool ReleaseCandidate;
            public string InputPath;
            public string FilePattern;
            public HeaderUpdateTool.LicenseType LicenseType;
            public bool Silent;
            public string Annex1Path;
            public string Annex2Path;            
            public IList<string> ModelUris;
            public string OutputPrefix;
        }

        private static void AddCompileOptions(CommandLineApplication app)
        {
            app.Option(
                $"-{OptionsNames.DesignFiles}",
                "The path to the ModelDesign or NodeSet2 file which contains the UA information model. The first file specified is the model to generate. The rest are included models. The file path may be followed by the namespace prefix and a short name for model. Commas seperate each field.",
                CommandOptionType.MultipleValue);

            app.Option(
                $"-{OptionsNames.IdentifierFile}",
                "The path to the CSV file which contains the unique identifiers for the types defined in the UA information model. Not used if the target is a NodeSet2 file.",
                CommandOptionType.SingleValue);

            app.Option(
                $"-{OptionsNames.GenerateIdentifierFile}",
                "Creates the identifier file if it does not exist (used instead of the -c option).",
                CommandOptionType.SingleValue);

            app.Option(
                $"-{OptionsNames.OutputPath}",
                "The output directory for the generated files.",
                CommandOptionType.SingleValue);

            app.Option(
                $"-{OptionsNames.AnsiCStackPath}",
                "The path to use when generating ANSI C stack code (internal use only).",
                CommandOptionType.SingleValue);

            app.Option(
                $"-{OptionsNames.DotNetStackPath}",
                "The path to use when generating .NET stack code (internal use only).",
                CommandOptionType.SingleValue);

            app.Option(
                $"-{OptionsNames.Version}",
                "Selects the source for the input files. v103 | v104 | v105 are supported.",
                CommandOptionType.SingleValue);

            app.Option(
                $"-{OptionsNames.UseAllowSubtypes}",
                "When subtypes are allowed for a field, C# code with the class name from the model is created instead of ExtensionObject. No effect when subtypes are not allowed.",
                CommandOptionType.NoValue);

            app.Option(
                $"-{OptionsNames.StartId}",
                "The first identifier to use when assigning new ids to nodes.",
                CommandOptionType.SingleValue);

            app.Option(
                $"-{OptionsNames.Exclusions}",
                "Comma seperated list of ReleaseStatus values to exclude from output.",
                CommandOptionType.SingleValue);

            app.Option(
                $"-{OptionsNames.ModelVersion}",
                "The version of the model to produce.",
                CommandOptionType.SingleValue);

            app.Option(
                $"-{OptionsNames.ModelPublicationDate}",
                "The publication date of the model to produce.",
                CommandOptionType.SingleValue);

            app.Option(
                $"-{OptionsNames.ReleaseCandidate}",
                "Indicates that a release candidate nodeset is being generated.",
                CommandOptionType.NoValue);

            app.Option(
                $"-{OptionsNames.OutputPrefix}",
                "The prefix to use on the generated files names.",
                CommandOptionType.SingleValue);
        }

        private static OptionValues GetCompileOptions(CommandLineApplication app)
        {
            var options = new OptionValues()
            {
                DesignFiles = app.GetOptionList(OptionsNames.DesignFiles),
                IdentifierFile = app.GetOption(OptionsNames.IdentifierFile),
                OutputPath = app.GetOption(OptionsNames.OutputPath),
                InputPath = app.GetOption(OptionsNames.InputPath),
                AnsiCStackPath = app.GetOption(OptionsNames.AnsiCStackPath),
                DotNetStackPath = app.GetOption(OptionsNames.DotNetStackPath),
                Version = app.GetOption(OptionsNames.Version),
                UseAllowSubtypes = app.IsOptionSet(OptionsNames.UseAllowSubtypes),
                ModelVersion = app.GetOption(OptionsNames.ModelVersion),
                ModelPublicationDate = app.GetOption(OptionsNames.ModelPublicationDate),
                ReleaseCandidate = app.IsOptionSet(OptionsNames.ReleaseCandidate),
                ModelUris = app.GetOptionList(OptionsNames.ModelUris),
                OutputPrefix = app.GetOption(OptionsNames.OutputPrefix),
            };

            var path = app.GetOption(OptionsNames.GenerateIdentifierFile);

            if (!String.IsNullOrEmpty(path))
            {
                options.IdentifierFile = path;
                options.CreateIdentifierFile = true;
            }

            var startId = app.GetOption(OptionsNames.StartId);

            if (!String.IsNullOrEmpty(startId))
            {
                options.StartId = UInt32.Parse(startId);
            }

            var exclusions = app.GetOption(OptionsNames.Exclusions);

            if (!String.IsNullOrEmpty(exclusions))
            {
                options.Exclusions = new List<string>(exclusions.Split(',', '+'));
            }

            return options;
        }

        private static void AddUpdateHeadersOptions(CommandLineApplication app)
        {
            app.Option(
                $"-{OptionsNames.InputPath}",
                "The path folders to search for files to update.",
                CommandOptionType.SingleValue);

            app.Option(
                $"-{OptionsNames.FilePattern}",
                "The file pattern to use when selecting files.",
                CommandOptionType.SingleValue);

            app.Option(
                $"-{OptionsNames.LicenseType}",
                "The type of license (MIT | MITXML | NONE).",
                CommandOptionType.SingleValue);

            app.Option(
                $"-{OptionsNames.Silent}",
                "Supresses any exceptions.",
                CommandOptionType.NoValue);
        }

        private static OptionValues GetUpdateHeadersOptions(CommandLineApplication app)
        {
            var options = new OptionValues()
            {
                InputPath = app.GetOption(OptionsNames.InputPath),
                FilePattern = app.GetOption(OptionsNames.FilePattern),
                Silent = app.IsOptionSet(OptionsNames.Silent)
            };

            var licenseType = app.GetOption(OptionsNames.LicenseType);

            if (!String.IsNullOrEmpty(licenseType))
            {
                options.LicenseType = Enum.Parse<HeaderUpdateTool.LicenseType>(licenseType);
            }

            return options;
        }

        private static void AddUnitsOptions(CommandLineApplication app)
        {
            app.Option(
                $"-{OptionsNames.Annex1Path}",
                "The path to the UNECE Annex 1 CSV file.",
                CommandOptionType.SingleValue);

            app.Option(
                $"-{OptionsNames.Annex2Path}",
                "The path to the UNECE Annex 2/3 CSV file.",
                CommandOptionType.SingleValue);

            app.Option(
                $"-{OptionsNames.UnitsOutputPath}",
                "The output directory.",
                CommandOptionType.SingleValue);
        }

        private static OptionValues GetUnitsOptions(CommandLineApplication app)
        {
            var options = new OptionValues()
            {
                Annex1Path = app.GetOption(OptionsNames.Annex1Path),
                Annex2Path = app.GetOption(OptionsNames.Annex2Path),
                OutputPath = app.GetOption(OptionsNames.UnitsOutputPath)
            };

            return options;
        }

        private static List<string> GetOptionList(this CommandLineApplication application, string name)
        {
            var option = application.Options
                .Where(x => x.ShortName == name && x.HasValue())
                .Select(x => x)
                .FirstOrDefault();

            if (option == null)
            {
                return new List<string>();
            }

            return new List<string>(option.Values);
        }

        private static string GetOption(this CommandLineApplication application, string name, string defaultValue = "")
        {
            var option = application.Options
                .Where(x => x.ShortName == name && x.HasValue())
                .Select(x => x)
                .FirstOrDefault();

            if (option == null)
            {
                return defaultValue;
            }

            return option.Value();
        }

        private static bool IsOptionSet(this CommandLineApplication application, string name, bool defaultValue = false)
        {
            var option = application.Options
                .Where(x => x.ShortName == name && x.HasValue())
                .Select(x => x)
                .FirstOrDefault();

            if (option == null)
            {
                return defaultValue;
            }

            return true;
        }
    }
    public class ApplicationErrorEventArgs
    {
        public ApplicationErrorEventArgs(string code, string text)
        {
            ErrorCode = code;
            ErrorText = text;
        }

        public string ErrorCode { get; }
        public string ErrorText { get; }
    }
}
