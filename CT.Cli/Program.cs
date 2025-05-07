// Program.cs
using System;
using System.CommandLine;

namespace HelloWorldCLI
{
    class Program
    {
        static int Main(string[] args)
        {
            // Create a root command
            var rootCommand = new RootCommand("A simple hello world CLI application.");

            // Add a name option
            var nameOption = new Option<string>(
                "--name",
                description: "The name to greet."
            )
            {
                IsRequired = false
            };
            nameOption.AddAlias("-n");
            rootCommand.AddOption(nameOption);

            // Set the handler
            rootCommand.SetHandler((string name) =>
            {
                // Console.WriteLine("Hello World!");
                if (!string.IsNullOrEmpty(name))
                {
                    Console.WriteLine($"Hello {name}!");
                }
                else{
                    Console.WriteLine("Hello World!");
                }
            }, nameOption);

            // Parse the command line arguments and invoke the handler
            return rootCommand.Invoke(args);
        }
    }
}