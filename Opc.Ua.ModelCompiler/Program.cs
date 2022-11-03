using ModelCompiler;
using McMaster.Extensions.CommandLineUtils;
using static System.Net.Mime.MediaTypeNames;
using System.Numerics;
using System.Reflection;
using System;

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
        //    "1.05.02",
        //    "-pd",
        //    "2022-10-01"
        //};

        //string[] args2 = {
        //    "compile",
        //    "-d2",
        //    @"D:\Work\OPC\nodesets\v105\BACnet\Opc.Ua.BACnet.NodeSet2.xml,BACnet,BACnet",
        //    // @"D:\Work\OPC\nodesets\v105\DI\Opc.Ua.DI.NodeSet2.xml,Opc.Ua.DI,DI",
        //    "-version",
        //    "v105",
        //    "-exclude",
        //    "Draft",
        //    "-o2",
        //    @"D:\Work\OPC\UA-ModelCompiler\Tests\DemoModel\BACnet"
        //};

        //string[] args2 = {
        //    "compile",
        //    "-d2",
        //    @"D:\Work\OPC\UA-ModelCompiler\Opc.Ua.ModelCompiler\Design.v105\OpcUaOnboardingModel.xml",
        //    "-d2",
        //    @"D:\Work\OPC\UA-ModelCompiler\Opc.Ua.ModelCompiler\Design.v105\OpcUaGdsModel.xml",
        //    "-version",
        //    "v105",
        //    "-exclude",
        //    "Draft",
        //    "-c",
        //    @"D:\Work\OPC\UA-ModelCompiler\Opc.Ua.ModelCompiler\CSVs\OpcUaOnboardingModel.csv",
        //    "-o2",
        //    @"D:\Work\OPC\nodesets\v105\OpcUaOnboardingModel"
        //};

        //string[] args2 = {
        //    "compile",
        //    "-d2",
        //    @"D:\Work\OPC\UA-ModelCompiler\Opc.Ua.ModelCompiler\Design.v105\DemoModel.xml",
        //    "-version",
        //    "v105",
        //    "-exclude",
        //    "Draft",
        //    "-c",
        //    @"D:\Work\OPC\UA-ModelCompiler\Opc.Ua.ModelCompiler\CSVs\DemoModel.csv",
        //    "-o2",
        //    @"D:\Work\OPC\UA-ModelCompiler\Tests\DemoModel\DemoModel"
        //};

        //string[] args2 = {
        //    "compile",
        //    "-d2",
        //    @"D:\Work\OPC\nodesets\v105\PlasticsRubber\Extrusion\GeneralTypes\1.01\Opc.Ua.PlasticsRubber.Extrusion.GeneralTypes.NodeSet2.xml,Opc.Ua.PlasticsRubber.Extrusion.GeneralTypes,PlasticsRubberExtrusionGeneralTypes",
        //    "-d2",
        //    @"D:\Work\OPC\nodesets\v105\PlasticsRubber\GeneralTypes\1.03\Opc.Ua.PlasticsRubber.GeneralTypes.NodeSet2.xml,Opc.Ua.PlasticsRubber.GeneralTypes,PlasticsRubberGeneralTypes",
        //    "-d2",
        //    @"D:\Work\OPC\nodesets\v105\DI\Opc.Ua.DI.NodeSet2.xml,Opc.Ua.DI,DI",
        //    "-version",
        //    "v105",
        //    "-exclude",
        //    "Draft",
        //    "-o2",
        //    @"D:\Work\OPC\UA-ModelCompiler\Tests\DemoModel\PlasticsRubberExtrusionGeneralTypes"
        //};

        //string[] args2 = {
        //    "compile",
        //    "-d2",
        //    @"D:\Work\OPC\UA-ModelCompiler\StructuresWithArrays.Nodeset2\StructuresWithArrays.Nodeset2.xml,StructuresWithArrays,StructuresWithArrays",
        //    "-version",
        //    "v105",
        //    "-exclude",
        //    "Draft",
        //    "-o2",
        //    @"D:\Work\OPC\UA-ModelCompiler\Tests\DemoModel\Models"
        //};

        //string[] args2 = {
        //    "compile-nodesets",
        //    "-input",
        //    @"D:\Work\OPC\nodesets\v105\",
        //    "-o2",
        //    @"D:\Work\OPC\UA-ModelCompiler\Tests\DemoModel\Models",
        //    "-uri",
        //    @"http://opcfoundation.org/UA/IEC61850-6",
        //    "-uri",
        //    @"http://opcfoundation.org/UA/IEC61850-7-4",
        //    "-uri",
        //    @"http://opcfoundation.org/UA/IEC61850-7-3",
        //};

        //ModelCompilerApplication.Run(args2);
        //return;
    }

    for (int ii = 0; ii < args.Length; ii++)
    {
        args[ii] = args[ii].Replace("\n", "\\n");
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