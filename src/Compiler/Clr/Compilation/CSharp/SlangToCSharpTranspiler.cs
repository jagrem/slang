using System.Text;
using slang.Compiler.Clr.Compilation.Core;

namespace slang.Compiler.Clr.Compilation.CSharp
{
    public static class SlangToCSharpTranspiler
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
                    {{");

                foreach (var function in moduleDefinition.FunctionDefinitions)
                {
                    sourceCode.Append($@"
                        { GetAccessModifier(function.AccessModifier) } static { function.ReturnType } { function.Name }()
                        {{
                            { function.Body }
                        }}
                    ");
                }

                foreach (var type in moduleDefinition.TypeDefinitions)
                {
                    sourceCode.Append($@"
                        { GetAccessModifier(type.AccessModifier) } class { type.Name }
                        {{
                        }}
                    ");
                }

                sourceCode.Append($@"
                    }}
                }}");
            }

            return sourceCode.ToString();
        }

        static string GetAccessModifier(AccessModifierType accessModifierType)
        {
            switch (accessModifierType)
            {
                default:
                    return "public";
            }
        }
    }
}
