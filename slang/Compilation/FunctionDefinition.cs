namespace slang.Compilation
{
    public class FunctionDefinition
    {
        public FunctionDefinition (string name, AccessModifierType accessModifier)
        {
            Name = name;
            AccessModifier = accessModifier;
        }

        public string Name { get; private set; }
        public AccessModifierType AccessModifier { get; private set; }
    }
}

