using System.CommandLine;
using Newtonsoft.Json;
using Opc.Ua;
using System;
using System.Globalization;

namespace ModelCompiler
{
    public static class ModelCompilerApplication
    {
        private static ITelemetryContext m_telemetry = DefaultTelemetry.Create(_ => { });
        private static readonly char[] trimChars = new char[] { '\\', '/' };

        public static async Task<int> Run(string[] args)
        {
            var rootCommand = new RootCommand("An application takes an OPC UA model file and generates code for the .NETStandard stack.");

            rootCommand.Subcommands.Add(CreateCompileCommand());
            rootCommand.Subcommands.Add(CreateUnitsCommand());
            rootCommand.Subcommands.Add(CreateUpdateHeadersCommand());
            rootCommand.Subcommands.Add(CreateCompileNodeSetsCommand());

            return await rootCommand.Parse(args).InvokeAsync().ConfigureAwait(false);
        }

        private static void WriteLine(string message, ConsoleColor color)
        {
            var current = System.Console.ForegroundColor;
            System.Console.ForegroundColor = color;
            System.Console.WriteLine(message);
            System.Console.ForegroundColor = current;
        }

        internal sealed class NodeSetInfo
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

#pragma warning disable CA1812
        internal sealed class NodeSetFile
        {
            public List<NodeSetInfo> NodeSets { get; set; }
        }
#pragma warning restore CA1812

        private static string GetNameFromUri(string uri)
        {
            var builder = new Uri(uri);
            var path = builder.LocalPath.TrimEnd('/');

            if (builder.Scheme == "urn")
            {
                var fields = builder.PathAndQuery.Split(':', StringSplitOptions.RemoveEmptyEntries);
                path = String.Join(".", fields, 2, fields.Length - 2);
            }

            if (path.StartsWith("/UA/", StringComparison.InvariantCulture))
            {
                path = path.Substring(4);
            }

            if (path.StartsWith("/OpcUa/", StringComparison.InvariantCulture))
            {
                path = path.Substring(7);
            }

            if (path == "/UA")
            {
                path = builder.DnsSafeHost;
            }

            return path.Trim('/')
                .Replace("/", "", StringComparison.InvariantCulture)
                .Replace('-', '_')
                .Replace('+', '_')
                .Replace(':', '_')
                .Replace('.', '_');
        }

        private static void LoadNodeSet(FileInfo file, Dictionary<string, NodeSetInfo> nodesets)
        {
            try
            {
                if (!NodeSetToModelDesign.IsNodeSet(LocalFileSystem.Instance, file.FullName))
                {
                    return;
                }

                using (var istrm = file.OpenRead())
                {
                    SystemContext context = new SystemContext(m_telemetry);
                    Opc.Ua.Export.UANodeSet nodeset = Opc.Ua.Export.UANodeSet.Read(istrm);
                    var collection = new NodeStateCollection();
                    context.NamespaceUris = new NamespaceTable(
                        new List<string>([Namespaces.OpcUa]).Concat(nodeset.NamespaceUris ?? Enumerable.Empty<string>()
                    ));
                    context.ServerUris = new StringTable(nodeset.ServerUris ?? []);

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
                        Version = model.PublicationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                        Name = name,
                        Prefix = "UAModel." + name,
                        Ignore = false,
                        NodeSet = nodeset
                    };

                    if (nodesets.TryGetValue(model.ModelUri, out var existing))
                    {
                        if (string.Compare(existing.Version, info.Version, StringComparison.Ordinal) < 0)
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

            var a = new FileInfo(".\\" + path1).FullName.ToUpperInvariant().Trim(trimChars);
            var b = new FileInfo(path2).FullName.ToUpperInvariant().Trim(trimChars);

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
                if (dependencies.ContainsKey(ns) || ns == target.ModelUri || ns == Namespaces.OpcUa)
                {
                    continue;
                }

                if (!nodesets.TryGetValue(ns, out NodeSetInfo nodeset))
                {
                    WriteLine($"NodeSet ({target.ModelUri}) dependency is missing ({ns}).", ConsoleColor.Red);
                    return false;
                }

                // favour the version in the same directory as the target.
                if (nodeset.PreviousVersions != null)
                {
                    if (Path.GetDirectoryName(nodeset.FileName) != Path.GetDirectoryName(target.FileName))
                    {
                        foreach (var ii in nodeset.PreviousVersions)
                        {
                            if (Path.GetDirectoryName(ii.FileName) == Path.GetDirectoryName(target.FileName))
                            {
                                nodeset = ii;
                                break;
                            }
                        }
                    }
                }

                dependencies[ns] = nodeset;

                if (!CollectDependencies(nodeset, nodesets, dependencies))
                {
                    return false;
                }
            }

            return true;
        }

        private static async Task GenerateCode(
            string inputPath,
            string outputPath,
            Dictionary<string, NodeSetInfo> nodesets,
            NodeSetInfo nodeset,
            Dictionary<string, NodeSetInfo> dependencies,
            OutputType suppressedOutputs = 0)
        {
            ModelGenerator2 generator = new ModelGenerator2(LocalFileSystem.Instance, m_telemetry);

            generator.AvailableNodeSets = nodesets.ToDictionary(x => x.Key, x => x.Value.FileName);

            generator.LogMessage += (e) =>
            {
                WriteLine(e.Message, (e.Severity > 0) ? ConsoleColor.Red : ConsoleColor.Yellow);
                return Task.CompletedTask;
            };

            List<string> files = new List<string>();
            files.Add($"{nodeset.FileName},{nodeset.Prefix},{nodeset.Name}");

            foreach (var dependency in dependencies.Values.Where(x => x.ModelUri != Namespaces.OpcUa))
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

            var path = new DirectoryInfo(inputPath).FullName;
            var relativePath = new FileInfo(nodeset.FileName).DirectoryName;

            if (relativePath.Length > path.Length)
            {
                relativePath = relativePath.Substring(path.Length);
            }
            else
            {
                relativePath = ".";
            }

            var output = outputPath; // Path.Combine(outputPath, relativePath);

            if (!Directory.Exists(output))
            {
                Directory.CreateDirectory(output);
            }

            WriteLine($"Writing to {Path.GetFullPath(output)}.", ConsoleColor.DarkYellow);

            var documentation = new FileInfo(nodeset.FileName.Replace(".xml", ".documentation.csv", StringComparison.InvariantCulture));

            if (documentation.Exists)
            {
                documentation.CopyTo(Path.Combine(output, $"{nodeset.Prefix}.NodeSet2.documentation.csv"), true);
            }

            await generator.GenerateMultipleFiles(
                output,
                false,
                exclusions,
                false,
                suppressedOutputs).ConfigureAwait(false);

            WriteLine($"NodeSet ({nodeset.ModelUri}) code generated ({output}).", ConsoleColor.DarkGreen);
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
            public const string SuppressOutput = "suppress";
        }

        private sealed class OptionValues
        {
            public List<string> DesignFiles;
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
            public string OutputPrefix;
            public OutputType SuppressedOutputs;
        }

        private static OptionValues GetCompileOptions(ParseResult parseResult,
            Option<string[]> designFilesOpt,
            Option<string> identifierFileOpt,
            Option<string> generateIdentifierFileOpt,
            Option<string> outputPathOpt,
            Option<string> ansiCStackPathOpt,
            Option<string> dotNetStackPathOpt,
            Option<string> versionOpt,
            Option<bool> useAllowSubtypesOpt,
            Option<string> startIdOpt,
            Option<string> exclusionsOpt,
            Option<string> modelVersionOpt,
            Option<string> modelPublicationDateOpt,
            Option<bool> releaseCandidateOpt,
            Option<string> outputPrefixOpt,
            Option<string> suppressOutputOpt)
        {
            var options = new OptionValues()
            {
                DesignFiles = new List<string>(parseResult.GetValue(designFilesOpt) ?? Array.Empty<string>()),
                IdentifierFile = parseResult.GetValue(identifierFileOpt) ?? "",
                OutputPath = parseResult.GetValue(outputPathOpt) ?? "",
                AnsiCStackPath = parseResult.GetValue(ansiCStackPathOpt) ?? "",
                DotNetStackPath = parseResult.GetValue(dotNetStackPathOpt) ?? "",
                Version = parseResult.GetValue(versionOpt) ?? "",
                UseAllowSubtypes = parseResult.GetValue(useAllowSubtypesOpt),
                ModelVersion = parseResult.GetValue(modelVersionOpt) ?? "",
                ModelPublicationDate = parseResult.GetValue(modelPublicationDateOpt) ?? "",
                ReleaseCandidate = parseResult.GetValue(releaseCandidateOpt),
                OutputPrefix = parseResult.GetValue(outputPrefixOpt) ?? "",
            };

            var path = parseResult.GetValue(generateIdentifierFileOpt) ?? "";

            if (!String.IsNullOrEmpty(path))
            {
                options.IdentifierFile = path;
                options.CreateIdentifierFile = true;
            }

            var startId = parseResult.GetValue(startIdOpt) ?? "";

            if (!String.IsNullOrEmpty(startId))
            {
                options.StartId = UInt32.Parse(startId, CultureInfo.InvariantCulture);
            }

            var exclusions = parseResult.GetValue(exclusionsOpt) ?? "";

            if (!String.IsNullOrEmpty(exclusions))
            {
                options.Exclusions = new List<string>(exclusions.Split(',', '+'));
            }

            var suppressOutput = parseResult.GetValue(suppressOutputOpt) ?? "";

            if (!String.IsNullOrEmpty(suppressOutput))
            {
                foreach (var value in suppressOutput.Split(','))
                {
                    if (Enum.TryParse<OutputType>(value.Trim(), true, out var outputType))
                    {
                        options.SuppressedOutputs |= outputType;
                    }
                }
            }

            return options;
        }

        private static Command CreateCompileCommand()
        {
            var command = new Command("compile", "Takes an OPC UA ModelDesign file and generates a NodeSet and code for the .NETStandard stack.");

            var designFilesOpt = new Option<string[]>($"-{OptionsNames.DesignFiles}")
            {
                Description = "The path to the ModelDesign or NodeSet2 file which contains the UA information model. The first file specified is the model to generate. The rest are included models. The file path may be followed by the namespace prefix and a short name for model. Commas seperate each field."
            };

            var identifierFileOpt = new Option<string>($"-{OptionsNames.IdentifierFile}")
            {
                Description = "The path to the CSV file which contains the unique identifiers for the types defined in the UA information model. Not used if the target is a NodeSet2 file."
            };

            var generateIdentifierFileOpt = new Option<string>($"-{OptionsNames.GenerateIdentifierFile}")
            {
                Description = "Creates the identifier file if it does not exist (used instead of the -c option)."
            };

            var outputPathOpt = new Option<string>($"-{OptionsNames.OutputPath}")
            {
                Description = "The output directory for the generated files."
            };

            var ansiCStackPathOpt = new Option<string>($"-{OptionsNames.AnsiCStackPath}")
            {
                Description = "The path to use when generating ANSI C stack code (internal use only)."
            };

            var dotNetStackPathOpt = new Option<string>($"-{OptionsNames.DotNetStackPath}")
            {
                Description = "The path to use when generating .NET stack code (internal use only)."
            };

            var versionOpt = new Option<string>($"-{OptionsNames.Version}")
            {
                Description = "Selects the source for the input files. v103 | v104 | v105 are supported."
            };

            var useAllowSubtypesOpt = new Option<bool>($"-{OptionsNames.UseAllowSubtypes}")
            {
                Description = "When subtypes are allowed for a field, C# code with the class name from the model is created instead of ExtensionObject. No effect when subtypes are not allowed."
            };

            var startIdOpt = new Option<string>($"-{OptionsNames.StartId}")
            {
                Description = "The first identifier to use when assigning new ids to nodes."
            };

            var exclusionsOpt = new Option<string>($"-{OptionsNames.Exclusions}")
            {
                Description = "Comma seperated list of ReleaseStatus values to exclude from output."
            };

            var modelVersionOpt = new Option<string>($"-{OptionsNames.ModelVersion}")
            {
                Description = "The version of the model to produce."
            };

            var modelPublicationDateOpt = new Option<string>($"-{OptionsNames.ModelPublicationDate}")
            {
                Description = "The publication date of the model to produce."
            };

            var releaseCandidateOpt = new Option<bool>($"-{OptionsNames.ReleaseCandidate}")
            {
                Description = "Indicates that a release candidate nodeset is being generated."
            };

            var outputPrefixOpt = new Option<string>($"-{OptionsNames.OutputPrefix}")
            {
                Description = "The prefix to use on the generated files names."
            };

            var suppressOutputOpt = new Option<string>($"-{OptionsNames.SuppressOutput}")
            {
                Description = "A comma separated list of output types to suppress (PredefinedNodes,Constants,NodeSet,JsonSchema,Classes,DataTypes)."
            };

            command.Options.Add(designFilesOpt);
            command.Options.Add(identifierFileOpt);
            command.Options.Add(generateIdentifierFileOpt);
            command.Options.Add(outputPathOpt);
            command.Options.Add(ansiCStackPathOpt);
            command.Options.Add(dotNetStackPathOpt);
            command.Options.Add(versionOpt);
            command.Options.Add(useAllowSubtypesOpt);
            command.Options.Add(startIdOpt);
            command.Options.Add(exclusionsOpt);
            command.Options.Add(modelVersionOpt);
            command.Options.Add(modelPublicationDateOpt);
            command.Options.Add(releaseCandidateOpt);
            command.Options.Add(outputPrefixOpt);
            command.Options.Add(suppressOutputOpt);

            command.SetAction(async (ParseResult parseResult, CancellationToken ct) =>
            {
                var options = GetCompileOptions(parseResult,
                    designFilesOpt, identifierFileOpt, generateIdentifierFileOpt,
                    outputPathOpt, ansiCStackPathOpt, dotNetStackPathOpt,
                    versionOpt, useAllowSubtypesOpt, startIdOpt,
                    exclusionsOpt, modelVersionOpt, modelPublicationDateOpt,
                    releaseCandidateOpt, outputPrefixOpt, suppressOutputOpt);

                ModelGenerator2 generator = new ModelGenerator2(LocalFileSystem.Instance, m_telemetry);

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
                        LocalFileSystem.Instance,
                        options.DesignFiles,
                        options.IdentifierFile,
                        options.DotNetStackPath,
                        options.Version,
                        options.Exclusions);

                    StackGenerator.GenerateOpenApi(
                        LocalFileSystem.Instance,
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
                        LocalFileSystem.Instance,
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

                    await generator.GenerateMultipleFiles(
                        options.OutputPath,
                        false,
                        options.Exclusions,
                        false,
                        options.SuppressedOutputs).ConfigureAwait(false);
                }
            });

            return command;
        }

        private static Command CreateUnitsCommand()
        {
            var command = new Command("units", "Generates the OPC UA Engineering Units CSV from the official UNECE table of units.");

            var annex1PathOpt = new Option<string>($"-{OptionsNames.Annex1Path}")
            {
                Description = "The path to the UNECE Annex 1 CSV file."
            };

            var annex2PathOpt = new Option<string>($"-{OptionsNames.Annex2Path}")
            {
                Description = "The path to the UNECE Annex 2/3 CSV file."
            };

            var outputPathOpt = new Option<string>($"-{OptionsNames.UnitsOutputPath}")
            {
                Description = "The output directory."
            };

            command.Options.Add(annex1PathOpt);
            command.Options.Add(annex2PathOpt);
            command.Options.Add(outputPathOpt);

            command.SetAction((ParseResult parseResult) =>
            {
                var options = new OptionValues()
                {
                    Annex1Path = parseResult.GetValue(annex1PathOpt) ?? "",
                    Annex2Path = parseResult.GetValue(annex2PathOpt) ?? "",
                    OutputPath = parseResult.GetValue(outputPathOpt) ?? ""
                };

                MeasurementUnits.Process(options.Annex1Path, options.Annex2Path, options.OutputPath);
            });

            return command;
        }

        private static Command CreateUpdateHeadersCommand()
        {
            var command = new Command("update-headers", "Updates all files in the output directory with the OPC Foundation MIT license header.");

            var inputPathOpt = new Option<string>($"-{OptionsNames.InputPath}")
            {
                Description = "The path folders to search for files to update."
            };

            var filePatternOpt = new Option<string>($"-{OptionsNames.FilePattern}")
            {
                Description = "The file pattern to use when selecting files."
            };

            var licenseTypeOpt = new Option<string>($"-{OptionsNames.LicenseType}")
            {
                Description = "The type of license (MIT | MITXML | NONE)."
            };

            var silentOpt = new Option<bool>($"-{OptionsNames.Silent}")
            {
                Description = "Supresses any exceptions."
            };

            command.Options.Add(inputPathOpt);
            command.Options.Add(filePatternOpt);
            command.Options.Add(licenseTypeOpt);
            command.Options.Add(silentOpt);

            command.SetAction((ParseResult parseResult) =>
            {
                var options = new OptionValues()
                {
                    InputPath = parseResult.GetValue(inputPathOpt) ?? "",
                    FilePattern = parseResult.GetValue(filePatternOpt) ?? "",
                    Silent = parseResult.GetValue(silentOpt)
                };

                var licenseType = parseResult.GetValue(licenseTypeOpt) ?? "";

                if (!String.IsNullOrEmpty(licenseType))
                {
                    options.LicenseType = Enum.Parse<HeaderUpdateTool.LicenseType>(licenseType);
                }

                HeaderUpdateTool.ProcessDirectory(options.InputPath, options.FilePattern, options.LicenseType, options.Silent);
            });

            return command;
        }

        private static Command CreateCompileNodeSetsCommand()
        {
            var command = new Command("compile-nodesets", "Searches a directory tree for nodesets and generates code for the specified model URIs.");

            var inputPathOpt = new Option<string>($"-{OptionsNames.InputPath}")
            {
                Description = "The path to the directory containing the nodesets."
            };

            var outputPathOpt = new Option<string>($"-{OptionsNames.OutputPath}")
            {
                Description = "The path to the directory to use to write the generated files."
            };

            var outputPrefixOpt = new Option<string>($"-{OptionsNames.OutputPrefix}")
            {
                Description = "The prefix on generated files."
            };

            var modelUrisOpt = new Option<string[]>($"-{OptionsNames.ModelUris}")
            {
                Description = "The URI of the model to generate."
            };

            var suppressOutputOpt = new Option<string>($"-{OptionsNames.SuppressOutput}")
            {
                Description = "A comma separated list of output types to suppress (PredefinedNodes,Constants,NodeSet,JsonSchema,Classes,DataTypes)."
            };

            command.Options.Add(inputPathOpt);
            command.Options.Add(outputPathOpt);
            command.Options.Add(outputPrefixOpt);
            command.Options.Add(modelUrisOpt);
            command.Options.Add(suppressOutputOpt);

            command.SetAction(async (ParseResult parseResult, CancellationToken ct) =>
            {
                var inputPath = parseResult.GetValue(inputPathOpt) ?? "";
                var outputPath = parseResult.GetValue(outputPathOpt) ?? "";
                var outputPrefix = parseResult.GetValue(outputPrefixOpt) ?? "";
                var modelUris = parseResult.GetValue(modelUrisOpt) ?? Array.Empty<string>();
                var suppressOutput = parseResult.GetValue(suppressOutputOpt) ?? "";

                OutputType suppressedOutputs = 0;

                if (!String.IsNullOrEmpty(suppressOutput))
                {
                    foreach (var value in suppressOutput.Split(','))
                    {
                        if (Enum.TryParse<OutputType>(value.Trim(), true, out var outputType))
                        {
                            suppressedOutputs |= outputType;
                        }
                    }
                }

                var input = new DirectoryInfo(inputPath);

                if (!input.Exists)
                {
                    throw new ArgumentException($"The input directory does not exist ({inputPath}).");
                }

                Dictionary<string, NodeSetInfo> nodesets = new();
                CollectNodeSets(input, nodesets);
                WriteLine($"{nodesets.Count} NodeSets found.", ConsoleColor.Cyan);
                WriteLine($"Writing output to {outputPath}", ConsoleColor.Cyan);

                HashSet<string> found = new();

                foreach (var modelUri in modelUris)
                {
                    if (!nodesets.TryGetValue(modelUri, out NodeSetInfo nodeset))
                    {
                        continue;
                    }

                    var relativePath = new FileInfo(nodeset.FileName).DirectoryName;

                    if (relativePath.Length > input.FullName.Length)
                    {
                        relativePath = relativePath.Substring(input.FullName.Length);
                    }
                    else
                    {
                        relativePath = ".";
                    }

                    var output = Path.Combine(outputPath, relativePath);

                    if (Directory.Exists(output))
                    {
                        Directory.Delete(output, true);
                    }
                }

                foreach (var modelUri in modelUris)
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

                    if (!String.IsNullOrEmpty(outputPrefix))
                    {
                        nodeset.Prefix = nodeset.Prefix.Replace(
                            "UAModel",
                            outputPrefix,
                            StringComparison.Ordinal);

                        foreach (var dependency in dependencies)
                        {
                            dependency.Value.Prefix = dependency.Value.Prefix.Replace(
                                "UAModel",
                                outputPrefix,
                                StringComparison.Ordinal);
                        }
                    }

                    try
                    {
                        await GenerateCode(input.FullName, outputPath, nodesets, nodeset, dependencies, suppressedOutputs).ConfigureAwait(false);
                    }
                    catch (Exception e)
                    {
                        WriteLine($"NodeSet ({nodeset.ModelUri}) code generation failed: {e.Message}", ConsoleColor.Red);
                    }
                }

                foreach (var uri in modelUris)
                {
                    if (!found.Contains(uri))
                    {
                        WriteLine($"NodeSet ({uri}) not found!", ConsoleColor.Red);
                    }
                }
            });

            return command;
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
