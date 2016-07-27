using slang.Compiler.Core.Parsing.Ast;
using slang.Compiler.Clr.Compilation.Definitions;
using System.Collections.Generic;
using slang.Compiler.Clr.Compilation.Definitions.Builders;
using System.Linq;

namespace slang.Translation
{
    public static class AstTranslator
    {
        public static AssemblyDefinition TranslateToAssemblyDefinition(IEnumerable<Module> modules)
        {
            var builder = AssemblyDefinitionBuilder
                .Create ("MyAssembly")
                .AsLibrary ();

            modules.ToList ().ForEach (m => {
                builder.AddClass (c => c
                                  .WithName (m.ModuleDeclaration.Name)
                                  .Public ());
            });

            return builder.Build ();
        }
    }
}
