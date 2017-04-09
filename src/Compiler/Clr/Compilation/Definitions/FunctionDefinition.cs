namespace slang.Compiler.Clr.Compilation.Definitions
{
    public class FunctionDefinition
    {
        public string Name { get; }
        public AccessModifierType AccessModifier { get; }

        public FunctionDefinition (string name, AccessModifierType accessModifier)
        {
            Name = name;
            AccessModifier = accessModifier;
        }
    }
}
