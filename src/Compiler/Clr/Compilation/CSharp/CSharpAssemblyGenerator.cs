using System.Reflection;
using slang.Compiler.Clr.Compilation.Core;

namespace slang.Compiler.Clr.Compilation.CSharp
{
    public class CSharpAssemblyGenerator : IAssemblyGenerator
    {
        public Assembly GenerateDynamicAssembly(AssemblyDefinition assemblyDefinition)
        {
            const string codeToCompile = @"
            using System;

            namespace RoslynCompileSample
            {
                public class Writer
                {
                    public void Write(string message)
                    {
                        Console.WriteLine($""you said '{message}!'"");
                    }
                }
            }";

            return CSharpCompiler.CompileToInMemoryAssembly(
                new CSharpCompilationParameters(
                    assemblyDefinition.Name,
                    OutputType.DynamicallyLinkedLibrary,
                    codeToCompile));
        }
    }
}
