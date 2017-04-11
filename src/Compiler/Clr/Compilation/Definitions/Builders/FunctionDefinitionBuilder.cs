namespace slang.Compiler.Clr.Compilation.Definitions
{
    public class FunctionDefinitionBuilder
    {
        string _name;
        AccessModifierType _accessModifier = AccessModifierType.Undefined;

        FunctionDefinitionBuilder()
        {
        }

        public static FunctionDefinitionBuilder Create()
        {
            return new FunctionDefinitionBuilder();
        }

        public FunctionDefinitionBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public FunctionDefinitionBuilder Public()
        {
            _accessModifier = AccessModifierType.Public;
            return this;
        }

        public FunctionDefinition Build()
        {
            if(_accessModifier == AccessModifierType.Undefined) { 
                throw new MalformedDefinitionException ("Function definition requires an access modifier."); 
            }

            return new FunctionDefinition (_name, _accessModifier);
        }
    }
}

