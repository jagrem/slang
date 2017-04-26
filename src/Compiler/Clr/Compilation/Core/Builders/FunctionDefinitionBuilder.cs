namespace slang.Compiler.Clr.Compilation.Core.Builders
{
    public class FunctionDefinitionBuilder
    {
        string _name;
        string _returnType;
        AccessModifierType _accessModifier = AccessModifierType.Undefined;

        public FunctionDefinitionBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public FunctionDefinitionBuilder WithReturnType(string returnType)
        {
            _returnType = returnType;
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

            return new FunctionDefinition (_name, _returnType, _accessModifier);
        }
    }
}
