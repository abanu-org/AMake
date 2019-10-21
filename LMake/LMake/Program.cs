using LMake.Core;
using System;
using System.IO;

namespace LMake
{
    internal class Program
    {
        private static string GetMakeFile()
        {
            return Environment.CurrentDirectory + "\\.lmake";
        }

        private static bool HasMakeFile()
        {
            return File.Exists(GetMakeFile());
        }

        private static void Main(string[] args)
        {
            var cmdargs = new CommandlineArguments(args);
            if (HasMakeFile())
            {
                var parser = new BuildScriptGrammar();
                var ast = parser.Parse(File.ReadAllText(GetMakeFile()), ".lmake");
            }
            else
            {
                Console.WriteLine("No Makefile found");
            }
        }
    }
}