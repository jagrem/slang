using System.Reflection;
using System.Text;
using slang.Compiler.Clr.Compilation.Core;

namespace slang.Compiler.Clr.Compilation.CSharp
{
    public class CSharpAssemblyGenerator : IAssemblyGenerator
    {
        public Assembly GenerateDynamicAssembly(AssemblyDefinition assemblyDefinition)
        {
            var sourceCode = new StringBuilder();

            foreach (var moduleDefinition in assemblyDefinition.Modules)
            {
                sourceCode.Append($@"
                    namespace {moduleDefinition.Namespace}
                    {{
                        public static class {moduleDefinition.Name}
                        {{
                        }}
                    }}
                ");
            }

            return CSharpCompiler.CompileToInMemoryAssembly(
                new CSharpCompilationParameters(
                    assemblyDefinition.Name,
                    OutputType.DynamicallyLinkedLibrary,
                    sourceCode.ToString()));
        }
    }
}
