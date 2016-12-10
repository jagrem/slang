using System.Diagnostics;
using System;
using System.IO;

namespace sc.Tests
{
    public static class Compiler {
        public static string CompileFromSource(string filename)
        {
            if (!File.Exists (filename))
                throw new CompilationException ("Can't find file.", string.Empty);

            if (!File.Exists ("sc.exe"))
                throw new CompilationException ("Can't find sc.exe.", string.Empty);

            var processInfo = new ProcessStartInfo ();
            processInfo.WorkingDirectory = @".\";
            processInfo.FileName = "sc.exe";
            processInfo.Arguments = filename;
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;
            using (var process = Process.Start (processInfo)) {
                
                process.WaitForExit ();

                var stderror = process.StandardError.ReadToEnd ();
                var stdout = process.StandardOutput.ReadToEnd ();
                var message = stdout + stderror;

                var exitCode = process.ExitCode;

                if (exitCode == 0) {
                    return Path.GetFileNameWithoutExtension (filename) + ".dll";
                }
                   
                switch (exitCode) {
                case 1:
                    throw new CompilationException ("Could not find file.", message);
                case 2:
                    throw new CompilationException ("File didn't have .sl extension.", message);
                case 3:
                    throw new CompilationException ("Parse error.", message);
                case 4:
                    throw new CompilationException ("Compile error.", message);
                case 5:
                    throw new CompilationException ("IL generation error.", message);
                default:
                    throw new CompilationException ("Unknown error.", message);
                }    
            }
        }
    }

    public class CompilationException : Exception
    {
        public CompilationException(string message, string details) : base(message + details) {
        }
    }
}
