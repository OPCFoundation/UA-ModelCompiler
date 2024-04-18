using ModelCompiler;
using McMaster.Extensions.CommandLineUtils;
using System.Reflection;
using System.Diagnostics;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;
using Opc.Ua;

try
{
    if (System.Diagnostics.Debugger.IsAttached)
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
        //    "1.05.03",
        //    "-pd",
        //    "2023-11-15"
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
        //    @"D:\Work\OPC\UA-ModelCompiler\Tests\DemoModel\DemoModel"
        //};

        //string[] args2 = {
        //    "compile",
        //    "-d2",
        //    @"D:\Work\OPC\UA-ModelCompiler\Opc.Ua.ModelCompiler\Design.v105\OpcUaGdsModel.xml",
        //    "-cg",
        //    @"D:\Work\OPC\UA-ModelCompiler\Opc.Ua.ModelCompiler\CSVs\OpcUaGdsModel.csv",
        //    "-version",
        //    "v105",
        //    "-exclude",
        //    "Draft",
        //    "-o2",
        //    @"D:\Work\OPC\UA-ModelCompiler\Tests\DemoModel\GDS"
        //};

        //string[] args2 = {
        //    "compile",
        //    //"-d2",
        //    //@"D:\Work\OPC\UA-ModelCompiler\Opc.Ua.ModelCompiler\Design.v105\OpcUaOnboardingModel.xml",
        //    "-d2",
        //    @"D:\Work\OPC\UA-ModelCompiler\Opc.Ua.ModelCompiler\Design.v105\OpcUaGdsModel.xml",
        //    "-version",
        //    "v105",
        //    "-exclude",
        //    "Draft",
        //    "-c",
        //    @"D:\Work\OPC\UA-ModelCompiler\Opc.Ua.ModelCompiler\CSVs\OpcUaGdsModel.csv",
        //    "-o2",
        //    @"D:\Work\OPC\nodesets\v105\GDS\"
        //};

        //string[] args2 = {
        //    "compile",
        //    "-d2",
        //    @"D:\Work\OPC\UA-ModelCompiler\Opc.Ua.ModelCompiler\Design.v105\I4AAS.IRDI.xml",
        //    "-version",
        //    "v105",
        //    "-exclude",
        //    "Draft",
        //    "-cg",
        //    @"D:\Work\OPC\UA-ModelCompiler\Opc.Ua.ModelCompiler\CSVs\I4AAS.IRDI.csv",
        //    "-o2",
        //    @"D:\Work\OPC\UA-REST-StarterKit\I4AAS-Gateway\Server\I4AAS\"
        //};

        //string[] args2 = {
        //    "compile",
        //    "-d2",
        //    @"D:\Work\OPC\UA-ModelCompiler\Opc.Ua.ModelCompiler\Design.v105\I4AAS.Submodels.xml",
        //    "-d2",
        //    @"D:\Work\OPC\UA-ModelCompiler\Opc.Ua.ModelCompiler\Design.v105\I4AAS.IRDI.xml",
        //    "-version",
        //    "v105",
        //    "-exclude",
        //    "Draft",
        //    "-cg",
        //    @"D:\Work\OPC\UA-ModelCompiler\Opc.Ua.ModelCompiler\CSVs\I4AAS.Submodels.csv",
        //    "-o2",
        //    @"D:\Work\OPC\UA-REST-StarterKit\I4AAS-Gateway\Server\I4AAS\"
        //};

        //string[] args2 = {
        //"compile",
        //"-d2",
        //@"I4AAS.DigitalNameplate.xml",
        //"-d2",
        //@"I4AAS.IRDI.References.xml",
        //"-version",
        //"v105",
        //"-exclude",
        //"Draft",
        //"-c",
        //@"I4AAS.csv",
        //"-o2",
        //@"I4AAS"
        //};

        //string[] args2 = {
        //    "compile",
        //    "-d2",
        //    @"D:\Work\OPC\UA-ModelCompiler\Tests\DemoModel\Models\CompressorSimulationOpcUaServer\CompressorSimulationOpcUaServer.NodeSet2.xml,CompressorSimulationOpcUaServer",
        //    //"-cg",
        //    //@"D:\Work\OPC\UA-ModelCompiler\Opc.Ua.ModelCompiler\CSVs\DemoModel.csv",
        //    "-version",
        //    "v105",
        //    "-exclude",
        //    "Draft",
        //    "-id",
        //    "9521",
        //    "-o2",
        //    @"D:\Work\OPC\UA-ModelCompiler\Tests\DemoModel\Models\CompressorSimulationOpcUaServer"
        //};

        //string[] args2 = {
        //    "compile",
        //    "-d2",
        //    @"D:\Work\OPC\UA-ModelCompiler-Public\Opc.Ua.ModelCompiler\Design.v105\XMLFile1.xml",        
        //    "-cg",
        //    @"D:\Work\OPC\UA-ModelCompiler-Public\Tests\DemoModel\Models\TestsModel.csv",
        //    "-version",
        //    "v105",
        //    "-exclude",
        //    "Draft",
        //    "-o2",
        //    @"D:\Work\OPC\UA-ModelCompiler-Public\Tests\DemoModel\Models"
        //};

        string[] args2 = {
            "compile-nodesets",
            "-input",
            @"D:\Work\OPC\UA-ModelCompiler-Public\NodeSet",
            "-o2",
            @"D:\Work\OPC\UA-ModelCompiler-Public\Tests\DemoModel\Models",
            "-uri",
            @"http://limula.ch/SensingModule/",
            "-prefix",
            "UAModel.SensingModule",
        };

        ModelCompilerApplication.Run(args2);
        return;
    }

    for (int ii = 0; ii < args.Length; ii++)
    {
        args[ii] = args[ii].Replace("\n", "\\n");
    }

    if (args.Length < 2) 
    {
        Console.WriteLine($"Version: {Assembly.GetExecutingAssembly().GetName().FullName}");
        Console.WriteLine($"FileVersion: {FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion}");
        Console.WriteLine($"Opc.Ua.Core: {typeof(Opc.Ua.NodeId).Assembly.GetName().FullName}");
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