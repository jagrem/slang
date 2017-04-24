using slang.Compiler.Core.Parsing.Ast;
using slang.Compiler.Clr.Compilation.Core;
using System.Collections.Generic;
using slang.Compiler.Clr.Compilation.Core.Builders;
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

            modules.ToList ().ForEach (m => builder.AddModule (c => c.WithName (m.ModuleDeclaration.Name)));

            return builder.Build ();
        }

        public static AssemblyDefinitionBuilder AddModule (this AssemblyDefinitionBuilder builder, Module module)
        {
            return builder.AddModule (c => c.WithName (module.ModuleDeclaration.Name));
        }
    }
}
