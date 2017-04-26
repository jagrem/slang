using System.Text;
using slang.Compiler.Clr.Compilation.Core;

namespace slang.Compiler.Clr.Compilation.CSharp
{
    public class SlangToCSharpTranspiler
    {
        public static string Transpile(AssemblyDefinition assemblyDefinition)
        {
            var sourceCode = new StringBuilder();

            foreach (var moduleDefinition in assemblyDefinition.Modules)
            {
                sourceCode.Append($@"
                    namespace { moduleDefinition.Namespace }
                    {{
                        public static class { moduleDefinition.Name }
                        {{
                        }}
                    }}
                ");
            }

            return sourceCode.ToString();
        }
    }
}
