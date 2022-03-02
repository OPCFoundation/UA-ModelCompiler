using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.CommandLineUtils;
using Opc.Ua;

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

            app.OnExecute(() =>
            {
                app.ShowHelp();
                return 0;
            });

            app.Execute(args);
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

                for (int ii = 0; ii < options.DesignFiles.Count; ii++)
                {
                    if (String.IsNullOrEmpty(options.DesignFiles[ii]))
                    {
                        throw new ArgumentException("No design file specified.");
                    }

                    if (!new FileInfo(options.DesignFiles[ii]).Exists)
                    {
                        throw new ArgumentException("The design file does not exist: " + options.DesignFiles[ii]);
                    }
                }

                if (String.IsNullOrEmpty(options.IdentifierFile))
                {
                    throw new ArgumentException("No identifier file specified.");
                }

                if (!new FileInfo(options.IdentifierFile).Exists)
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
                    options.ReleaseCandidate);

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
        }

        private static void AddCompileOptions(CommandLineApplication app)
        {
            app.Option(
                $"-{OptionsNames.DesignFiles}",
                "The path to the ModelDesign file which contains the UA information model.",
                CommandOptionType.MultipleValue);

            app.Option(
                $"-{OptionsNames.IdentifierFile}",
                "The path to the CSV file which contains the unique identifiers for the types defined in the UA information model.",
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
                "The path to use when generating ANSI C stack code.",
                CommandOptionType.SingleValue);

            app.Option(
                $"-{OptionsNames.DotNetStackPath}",
                "The path to use when generating .NET stack code.",
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
        }

        private static OptionValues GetCompileOptions(CommandLineApplication app)
        {
            var options = new OptionValues()
            {
                DesignFiles = app.GetOptionList(OptionsNames.DesignFiles),
                IdentifierFile = app.GetOption(OptionsNames.IdentifierFile),
                OutputPath = app.GetOption(OptionsNames.OutputPath),
                AnsiCStackPath = app.GetOption(OptionsNames.AnsiCStackPath),
                DotNetStackPath = app.GetOption(OptionsNames.DotNetStackPath),
                Version = app.GetOption(OptionsNames.Version),
                UseAllowSubtypes = app.IsOptionSet(OptionsNames.UseAllowSubtypes),
                ModelVersion = app.GetOption(OptionsNames.ModelVersion),
                ModelPublicationDate = app.GetOption(OptionsNames.ModelPublicationDate),
                ReleaseCandidate = app.IsOptionSet(OptionsNames.ReleaseCandidate)
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

            var categories = app.GetOption(OptionsNames.Exclusions);

            if (!String.IsNullOrEmpty(categories))
            {
                options.Exclusions = new List<string>(categories.Split(',', '+'));
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
            var option = application.Options.Find((ii) => { return ii.ShortName == name && ii.HasValue(); });

            if (option == null)
            {
                return new List<string>();
            }

            return option.Values;
        }

        private static string GetOption(this CommandLineApplication application, string name, string defaultValue = "")
        {
            var option = application.Options.Find((ii) => { return ii.ShortName == name && ii.HasValue(); });

            if (option == null)
            {
                return defaultValue;
            }

            return option.Value();
        }

        private static bool IsOptionSet(this CommandLineApplication application, string name, bool defaultValue = false)
        {
            application.Options[0].HasValue();
            var option = application.Options.Find((ii) => { return ii.ShortName == name && ii.HasValue(); });

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
