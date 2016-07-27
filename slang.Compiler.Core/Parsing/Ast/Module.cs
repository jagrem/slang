using System.Collections.Generic;

namespace slang.Compiler.Core.Parsing.Ast
{
    public class Module
    {
        public ModuleDeclaration ModuleDeclaration { get; private set; }
        public IEnumerable<Binding> Bindings { get; private set; }

        public Module (ModuleDeclaration moduleDeclaration, IEnumerable<Binding> bindings)
        {
            ModuleDeclaration = moduleDeclaration;
            Bindings = bindings;
        }
    }
}

