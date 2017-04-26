using System.Reflection;
using slang.Compiler.Clr.Compilation.Core;

namespace slang.Compiler.Clr.Compilation.CSharp
{
    public class CSharpAssemblyGenerator : IAssemblyGenerator
    {
        public Assembly GenerateDynamicAssembly(AssemblyDefinition assemblyDefinition)
        {
            return CSharpCompiler.CompileToInMemoryAssembly(
                new CSharpCompilationParameters(
                    assemblyDefinition.Name,
                    OutputType.DynamicallyLinkedLibrary,
                    SlangToCSharpTranspiler.Transpile(assemblyDefinition)));
        }
    }
}
