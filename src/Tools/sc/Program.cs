using System;
using slang.Compilation;
using slang.Compiler.Core.Compilation;
using System.Linq;
using sc.Terminal;

namespace sc
{
    class MainClass
    {
        public static void Main (string[] args)
        {
            Messages.WriteLogo ();
            Messages.WriteHeader ();
            ValidateArgs (args);
            var solution = BuildCompilationRoot (args[0]);

            try {
                SlangCompiler.Compile (solution);
            } catch (Exception e) {
                Messages.WriteError ("{0}", e.Message);
                Environment.Exit (e.HResult);
            }

            Environment.Exit (0);
        }

        static void ValidateArgs (string [] args)
        {
            if (args.Length < 1) {
                Messages.WriteError ("No project.json file specified.");
                Messages.WriteUsage ();
                Environment.Exit (1);
            }
        }

        static CompilationRoot BuildCompilationRoot (string projectName)
        {
            var projectMetadata = new CompilationMetadata (projectName, string.Empty, AssemblyType.Executable);
            var project = new CompilationUnit (projectMetadata, Enumerable.Empty<string> ());
            return new CompilationRoot (new [] { project });
        }
    }
}
