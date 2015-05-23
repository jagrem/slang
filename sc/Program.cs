using System;
using System.IO;
using slang.Parsing;
using slang.Compilation;
using slang.IL;
using slang.AST;

namespace sc
{
    class MainClass
    {
        public static void Main (string[] args)
        {
            if(args.Length == 0) {
                Console.Error.WriteLine ("No files specified.");
            }

            foreach(var arg in args) {
                if(!File.Exists (arg)) {
                    Console.Error.WriteLine ("Input file: '{0}' does not exist.", arg);
                    Environment.Exit (1);
                }

                if(Path.GetExtension (arg) != ".sl") {
                    Console.Error.WriteLine ("Input file: '{0}' does not have an .sl extension.", arg);
                    Environment.Exit (2);
                }

                var parser = new SlangParser ();
                ProgramNode root = null;

                try {
                    root = parser.Parse (File.ReadAllText (arg));
                } catch(Exception e) {
                    Console.Error.WriteLine ("Parse error: {0}.", e);
                    Environment.Exit (3);
                }

                AssemblyDefinition assemblyDefinition = null;

                try {
                    var compiler = new Compiler ();
                    assemblyDefinition = compiler.Compile (root);
                } catch(Exception e) {
                    Console.Error.WriteLine ("Compile error: {0}.", e);
                    Environment.Exit (4);
                }

                try {
                Generator.GenerateAssembly (assemblyDefinition);
                } catch(Exception e) {
                    Console.Error.WriteLine ("IL generation error: {0}.", e);
                    Environment.Exit (5);
                }
            }

            Environment.Exit (0);
        }
    }
}
