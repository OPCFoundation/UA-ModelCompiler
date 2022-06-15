using ModelCompiler;
using Microsoft.Extensions.CommandLineUtils;

try
{
    for (int ii = 0; ii < args.Length; ii++)
    {;
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