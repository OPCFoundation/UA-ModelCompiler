using McMaster.Extensions.CommandLineUtils;
using ModelCompiler;
using Opc.Ua;
using System.Diagnostics;
using System.Reflection;

internal sealed class Program
{
    private static Task Main(string[] args)
    {
        try
        {
            if (Debugger.IsAttached)
            {
                //string[] args2 = {
                //    "compile",
                //    "-d2",
                //    @"D:\Work\OPC\UA-ModelCompiler\Opc.Ua.ModelCompiler\Design.v105\StandardTypes.xml",
                //    "-d2",
                //    @"D:\Work\OPC\UA-ModelCompiler\Opc.Ua.ModelCompiler\Design.v105\UA Core Services.xml",
                //    "-version",
                //    "v105",
                //    "-exclude",
                //    "Draft",
                //    "-c",
                //    @"D:\Work\OPC\UA-ModelCompiler\Opc.Ua.ModelCompiler\CSVs\StandardTypes.csv",
                //    "-o2",
                //    @"D:\Work\OPC\nodesets\v105\Schema\",
                //    "-stack",
                //    @"D:\Work\OPC\nodesets\v105\DotNet\",
                //    "-ansic",
                //    @"D:\Work\OPC\nodesets\v105\AnsiC\",
                //    "-mv",
                //    "1.05.06",
                //    "-pd",
                //    "2025-11-08"
                //};

                //string[] args2 = {
                //    "compile-nodesets",
                //    "-input",
                //    @"D:\Work\OPC\UA-WebApi-StarterKit\UaWebApiClient\NodeSets",
                //    "-uri",
                //    "urn:opcfoundation.org:2024-10:starterkit:measurements",
                //    "-prefix",
                //    "Measurements",
                //    "-o2",
                //    @"D:\Work\OPC\UA-WebApi-StarterKit\UaWebApiClient\Model\Measurements\"
                //};

                //string[] args2 = {
                //    "compile",
                //    "-version",
                //    "v105",
                //    "-d2",
                //    @"D:\Work\OPC\UAMC\Opc.Ua.ModelCompiler\Design.v105\TestModel.xml",
                //    "-cg",
                //    @"D:\Work\OPC\UAMC\Opc.Ua.ModelCompiler\CSVs\TestModel.csv",
                //    "-o2",
                //    @"D:\Work\OPC\UAMC\Tests\DemoModel\TestModel\"
                //};

                //ModelCompilerApplication.Run(args2);

                //string[] args2 = {
                //    "compile",
                //    "-d2",
                //    @"D:\Work\OPC\UA-ModelCompiler\Opc.Ua.ModelCompiler\Design.v105\OpcUaDiModel.xml",
                //    "-cg",
                //    @"D:\Work\OPC\UA-ModelCompiler\Opc.Ua.ModelCompiler\CSVs\OpcUaDiModel.csv",
                //    "-version",
                //    "v105",
                //    "-exclude",
                //    "Draft",
                //    "-o2",
                //    @"D:\Work\OPC\nodesets\v105\DI\"
                //};

                //string[] args2 = {
                //    "compile",
                //    "-d2",
                //    @"D:\Work\OPC\UA-ModelCompiler\Opc.Ua.ModelCompiler\Design.v105\OpcUaDiPackageMetadataModel.xml",
                //    "-cg",
                //    @"D:\Work\OPC\UA-ModelCompiler\Opc.Ua.ModelCompiler\CSVs\OpcUaDiPackageMetadataModel.csv",
                //    "-version",
                //    "v105",
                //    "-exclude",
                //    "Draft",
                //    "-o2",
                //    @"D:\Work\OPC\nodesets\v105\DI\"
                //};

                //ModelCompilerApplication.Run(args2);

                //string[] args3 = {
                //    "compile-nodesets",
                //    "-input",
                //    @"D:\Work\OPC\nodesets\v105\",
                //    "-o2",
                //    @"D:\Work\OPC\UA-ModelCompiler\Tests\DemoModel\Models\PackageMetadata",
                //    "-uri",
                //    @"http://opcfoundation.org/UA/DI/PackageMetadata/",
                //    "-prefix",
                //    "UAModel.DI.PackageMetadata"
                //};

                //ModelCompilerApplication.Run(args3);

                //string[] args2 = {
                //    "compile",
                //    "-d2",
                //    @"D:\Work\OPC\UA-ModelCompiler\Opc.Ua.ModelCompiler\Design.v105\OpcUaGdsModel.xml",
                //    "-cg",
                //    @"D:\Work\OPC\UA-ModelCompiler\Opc.Ua.ModelCompiler\CSVs\OpcUaGdsModel.csv",
                //    "-version",
                //    "v105",
                //    "-mv",
                //    "1.05.06",
                //    "-pd",
                //    "2025-07-01",
                //    "-exclude",
                //    "Nothing",
                //    "-o2",
                //    @"D:\Work\OPC\nodesets\v105\GDS\"
                //};

                //string[] args2 = {
                //    "compile",
                //    "-d2",
                //    @"D:\Work\OPC\UA-ModelCompiler\Opc.Ua.ModelCompiler\Design.v105\DemoModel.xml",
                //    "-cg",
                //    @"D:\Work\OPC\UA-ModelCompiler\Opc.Ua.ModelCompiler\CSVs\DemoModel.csv",
                //    "-version",
                //    "v105",
                //    "-exclude",
                //    "Draft",
                //    "-o2",
                //    @"D:\Work\OPC\nodesets\v105\DemoModel\"
                //};

                //string[] args2 = {
                //    "compile-nodesets",
                //    "-input",
                //    @"D:\Work\OPC\UAMC\input\",
                //    "-o2",
                //    //@"D:\Work\OPC\UA-ModelCompiler\Tests\DemoModel\Models\DI\",
                //    //@"D:\Work\OPC\UA-ModelCompiler\Tests\DemoModel\Models\IA\",
                //    //@"D:\Work\OPC\UA-ModelCompiler\Tests\DemoModel\Models\Machinery\",
                //    //@"D:\Work\OPC\UA-ModelCompiler\Tests\DemoModel\Models\MachineryResult\",
                //    //@"D:\Work\OPC\UA-ModelCompiler\Tests\DemoModel\Models\ISA95_JOBCONTROL_V2\",
                //    //@"D:\Work\OPC\UA-ModelCompiler\Tests\DemoModel\Models\MachineryJobs\",
                //     //@"D:\Work\OPC\UA-ModelCompiler\Tests\DemoModel\Models\WireHarnessVEC\",
                //    @"D:\Work\OPC\UAMC\output\",
                //    "-uri",
                //    //@"http://opcfoundation.org/UA/DI/",
                //    //@"http://opcfoundation.org/UA/IA/",
                //    //@"http://opcfoundation.org/UA/Machinery/",
                //    //@"http://opcfoundation.org/UA/Machinery/Result/",
                //    //@"http://opcfoundation.org/UA/ISA95-JOBCONTROL_V2/",
                //    //@"http://opcfoundation.org/UA/Machinery/Jobs/",
                //    //@"http://opcfoundation.org/UA/WireHarness/VEC/",
                //    //@"http://opcfoundation.org/UA/WireHarness/",
                //    @"http://vw.com/audiag/OpcUa/CentralIm/",
                //    "-prefix",
                //    //"UAModel.DI",
                //    //"UAModel.IA",
                //    //"UAModel.Machinery",
                //    //"UAModel.MachineryResult",
                //    //"UAModel.ISA95_JOBCONTROL_V2",
                //    //"UAModel.MachineryJobs",
                //    //"UAModel.WireHarnessVEC",
                //    "vw.audiag"
                //};

                //ModelCompilerApplication.Run(args2);

                //File.Copy(
                //    @"D:\Work\OPC\UA-IIoT-StarterKit\Opc.Ua.TestPublisher\Model",
                //    @"D:\Work\OPC\UA-IIoT-StarterKit\Opc.Ua.TestPublisher\Model");

                return Task.CompletedTask;
            }

            for (int ii = 0; ii < args.Length; ii++)
            {
                args[ii] = args[ii].Replace("\n", "\\n", StringComparison.InvariantCulture);
            }

            if (args.Length < 2)
            {
                Console.WriteLine($"Version: {Assembly.GetExecutingAssembly().GetName().FullName}");
                Console.WriteLine($"FileVersion: {FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion}");
                Console.WriteLine($"Opc.Ua.Core: {typeof(NodeId).Assembly.GetName().FullName}");
            }

            ModelCompilerApplication.Run(args);
        }
        catch (CommandParsingException e)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[{e.GetType().Name}] {e.Message} ({e.Command})");
            Environment.Exit(3);
        }
        catch (AggregateException e)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[{e.GetType().Name}] {e.Message}");

            foreach (var ie in e.InnerExceptions)
            {
                Console.WriteLine($">>> [{ie.GetType().Name}] {ie.Message}");
            }

            Environment.Exit(3);
        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[{e.GetType().Name}] {e.Message}");

            Exception ie = e.InnerException;

            while (ie != null)
            {
                Console.WriteLine($">>> [{ie.GetType().Name}] {ie.Message}");
                ie = ie.InnerException;
            }

            Console.WriteLine();
            Console.WriteLine($"========================");
            Console.WriteLine($"{e.StackTrace}");
            Console.WriteLine($"========================");
            Console.WriteLine();

            Environment.Exit(3);
        }
        return Task.CompletedTask;
    }
}