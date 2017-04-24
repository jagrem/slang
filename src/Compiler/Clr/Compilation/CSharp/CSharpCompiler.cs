using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;

namespace slang.Compiler.Clr.Compilation.CSharp
{
    public static class CSharpCompiler
    {
        public static CSharpCompilation Compile(CSharpCompilationParameters parameters)
        {
            var syntaxTree = CSharpSyntaxTree.ParseText(parameters.SourceCode);
            var references = new MetadataReference[] { MetadataReference.CreateFromFile(typeof(object).GetTypeInfo().Assembly.Location) };
            var options = new CSharpCompilationOptions(parameters.OutputType == Core.OutputType.DynamicallyLinkedLibrary ? OutputKind.DynamicallyLinkedLibrary : OutputKind.ConsoleApplication);

            return CSharpCompilation.Create(
                parameters.AssemblyName,
                syntaxTrees: new[] { syntaxTree },
                references: references,
                options: options);
        }

        public static Assembly CompileToInMemoryAssembly(CSharpCompilationParameters parameters)
        {
            var compilation = Compile(parameters);

            using (var stream = new MemoryStream())
            {
                EmitResult result = compilation.Emit(stream);

                if (!result.Success)
                {
                    var failures =
                        result.Diagnostics
                        .Where(diagnostic =>
                            diagnostic.IsWarningAsError ||
                            diagnostic.Severity == DiagnosticSeverity.Error)
                        .Select(diagnostic =>
                            $"[ERROR] { diagnostic.Id }: { diagnostic.GetMessage() }");
                    throw new Exception(string.Join(",", failures));
                }

                stream.Seek(0, SeekOrigin.Begin);

                return AssemblyLoadContext.Default.LoadFromStream(stream);
            }
        }
    }
}
