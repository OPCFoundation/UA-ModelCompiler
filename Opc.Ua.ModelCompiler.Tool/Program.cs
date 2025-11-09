using McMaster.Extensions.CommandLineUtils;
using ModelCompiler;
using Opc.Ua;
using System.Diagnostics;
using System.Reflection;

internal class Program
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
                //    "2025-10-31"
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
                //    @"D:\Work\OPC\UA-ModelCompiler\Opc.Ua.ModelCompiler\Design.v105\DemoModel.xml",
                //    "-d2",
                //    @"D:\Work\OPC\nodesets\public\UAFX\opc.ua.fx.ac.nodeset2.xml,Opc.UAFX.AC,Opc.UAFX.AC",
                //    "-d2",
                //    @"D:\Work\OPC\nodesets\public\UAFX\opc.ua.fx.cm.nodeset2.xml,Opc.UAFX.CM,Opc.UAFX.CM",
                //    "-d2",
                //    @"D:\Work\OPC\nodesets\public\UAFX\opc.ua.fx.data.nodeset2.xml,Opc.UAFX.Data,Opc.UAFX.Data",
                //    "-d2",
                //    @"D:\Work\OPC\nodesets\public\DI\Opc.Ua.Di.NodeSet2.xml,Opc.Ua.Di,Opc.Ua.Di",
                //    "-cg",
                //    @"D:\Work\OPC\UA-ModelCompiler\Opc.Ua.ModelCompiler\CSVs\DemoModel.csv",
                //    "-o2",
                //    @"D:\Work\OPC\UA-ModelCompiler\Tests\DemoModel\Models\"
                //};

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
                //    @"D:\Work\OPC\UA-ModelCompiler\Opc.Ua.ModelCompiler\Design.v105\OpcUaDiSoftwarePackageModel.xml",
                //    "-cg",
                //    @"D:\Work\OPC\UA-ModelCompiler\Opc.Ua.ModelCompiler\CSVs\OpcUaDiSoftwarePackageModel.csv",
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

                //ModelCompilerApplication.Run(args2);

                //string[] args3 = {
                //    "compile-nodesets",
                //    "-input",
                //    @"D:\Work\OPC\nodesets\v105\",
                //    "-o2",
                //    @"D:\Work\OPC\UA-ModelCompiler\Tests\DemoModel\Models\SoftwarePackage",
                //    "-uri",
                //    @"http://opcfoundation.org/UA/DI/SoftwarePackage/",
                //    "-prefix",
                //    "UAModel.DI.SoftwarePackage"
                //};

                //ModelCompilerApplication.Run(args3);

                //string[] args2 = {
                //    "compile -d2 NodeSet1.xml -d2 NodeSet2.xml -cg",
                //    @"D:\Work\OPC\UA-ModelCompiler\Opc.Ua.ModelCompiler\CSVs\I4AAS.Submodels.csv",
                //    "-version",
                //    "v103",
                //    "-exclude",
                //    "Draft",
                //    "-o2",
                //    @"D:\Work\OPC\UA-ModelCompiler\ModelDesigns\ModelDesigns\Generated\"
                //};

                //string[] args2 = {
                //    "compile",
                //    "-d2",
                //    @"D:\Work\OPC\UA-ModelCompiler\Opc.Ua.ModelCompiler\Design.v105\WotConnection.xml",
                //    "-cg",
                //    @"D:\Work\OPC\UA-ModelCompiler\Opc.Ua.ModelCompiler\CSVs\WotConnection.csv",
                //    "-version",
                //    "v105",
                //    "-exclude",
                //    "Draft",
                //    "-o2",
                //    @"D:\Work\OPC\nodesets\v105\WoT\"
                //};


                //string[] args2 = {
                //    "compile-nodesets",
                //    "-input",
                //    @"D:\Work\OPC\nodesets\v105\",
                //    "-o2",
                //    @"D:\Work\OPC\UA-ModelCompiler\Tests\DemoModel\Models\",
                //    "-uri",
                //    @"http://opcfoundation.org/UA/WoT-Con/",
                //    "-prefix",
                //    "UAModel.GMS"
                //};

                // ModelCompilerApplication.Run(args2);

                //File.Copy(
                //    @"D:\Work\OPC\UA-IIoT-StarterKit\Opc.Ua.TestPublisher\Model",
                //    @"D:\Work\OPC\UA-IIoT-StarterKit\Opc.Ua.TestPublisher\Model");

                //return;
            }

            for (int ii = 0; ii < args.Length; ii++)
            {
                args[ii] = args[ii].Replace("\n", "\\n",  StringComparison.InvariantCulture);
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