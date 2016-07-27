namespace slang.Compiler.Core.Parsing.Ast
{
    public class ModuleDeclaration
    {
        public string Name { get; private set; }

        public ModuleDeclaration (string moduleName)
        {
            Name = moduleName;
        }
    }
}

