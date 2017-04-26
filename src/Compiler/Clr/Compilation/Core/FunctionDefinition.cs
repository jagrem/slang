namespace slang.Compiler.Clr.Compilation.Core
{
    public class FunctionDefinition
    {
        public string Name { get; }
        public string ReturnType { get; }
        public AccessModifierType AccessModifier { get; }

        public FunctionDefinition (string name, string returnType, AccessModifierType accessModifier)
        {
            Name = name;
            ReturnType = returnType;
            AccessModifier = accessModifier;
        }
    }
}
