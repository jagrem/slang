namespace slang.Compiler.Clr.Compilation.Core
{
    public class FunctionDefinition
    {
        public string Name { get; }
        public string ReturnType { get; }
        public AccessModifierType AccessModifier { get; }
        public string Body { get; }

        public FunctionDefinition (string name, string returnType, AccessModifierType accessModifier, string body)
        {
            Name = name;
            ReturnType = returnType;
            AccessModifier = accessModifier;
            Body = body;
        }
    }
}
