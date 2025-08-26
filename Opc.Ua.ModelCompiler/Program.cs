using ModelCompiler;
using McMaster.Extensions.CommandLineUtils;
using System.Reflection;
using System.Diagnostics;

try
{
    if (System.Diagnostics.Debugger.IsAttached)
    {
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
        //    @"D:\Work\OPC\UA-IIoT-StarterKit\Opc.Ua.TestPublisher\Model"
        //};

        //string[] args2 = {
        //    "compile-nodesets",
        //    "-input",
        //    @"D:\Work\OPC\nodesets\v105\",
        //    "-o2",
        //    @"D:\Work\OPC\UA-ModelCompiler-Public\Tests\DemoModel\Models\",
        //    "-uri",
        //    @"http://opcfoundation.org/UA/DI/",
        //    "-prefix",
        //    "UAModel.DI"
        //};

        string[] args2 = {
            "compile",
            "-version",
            "v105",
            "-d2",
            @"D:\Work\OPC\UA-ModelCompiler\Opc.Ua.ModelCompiler\Design.v105\DemoModel.xml",
            "-d2",
            @"D:\Work\OPC\nodesets\public\UAFX\opc.ua.fx.ac.nodeset2.xml,Opc.UAFX.AC,Opc.UAFX.AC",
            "-d2",
            @"D:\Work\OPC\nodesets\public\UAFX\opc.ua.fx.cm.nodeset2.xml,Opc.UAFX.CM,Opc.UAFX.CM",
            "-d2",
            @"D:\Work\OPC\nodesets\public\UAFX\opc.ua.fx.data.nodeset2.xml,Opc.UAFX.Data,Opc.UAFX.Data",
            "-d2",
            @"D:\Work\OPC\nodesets\public\DI\Opc.Ua.Di.NodeSet2.xml,Opc.Ua.Di,Opc.Ua.Di",
            "-cg",
            @"D:\Work\OPC\UA-ModelCompiler\Opc.Ua.ModelCompiler\CSVs\DemoModel.csv",
            "-o2",
            @"D:\Work\OPC\UA-ModelCompiler\Tests\DemoModel\Models\"
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