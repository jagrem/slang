namespace slang.Compiler.Clr.Compilation.Definitions
{
    public class FunctionDefinition
    {
        public string Name { get; private set; }
        public AccessModifierType AccessModifier { get; private set; }

        public FunctionDefinition (string name, AccessModifierType accessModifier)
        {
            Name = name;
            AccessModifier = accessModifier;
        }
    }
}
