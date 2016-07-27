namespace slang.Compiler.Core.Parsing.Ast
{
    public class TypeDeclaration
    {
        public string TypeName { get; private set; }

        public TypeDeclaration (string typeName)
        {
            TypeName = typeName;
        }
    }
}

