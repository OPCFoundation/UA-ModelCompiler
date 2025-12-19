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
            //if (Debugger.IsAttached)
            //{
            //    return Task.CompletedTask;
            //}

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