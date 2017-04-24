using System;
using System.Collections.Generic;
using System.Linq;

namespace slang.Compiler.Clr.Compilation.Core.Builders
{
    public class TypeDefinitionBuilder
    {
        string _className;
        string _namespace;
        AccessModifierType _accessModifier;
        readonly List<FunctionDefinitionBuilder> _functionDefinitionBuilders = new List<FunctionDefinitionBuilder>();

        TypeDefinitionBuilder() {}

        public static TypeDefinitionBuilder Create()
        {
            return new TypeDefinitionBuilder ();
        }

        public TypeDefinitionBuilder WithName(string className)
        {
            _className = className;
            return this;
        }

        public TypeDefinitionBuilder WithNamespace(string @namespace)
        {
            _namespace = @namespace;
            return this;
        }

        public TypeDefinitionBuilder Public()
        {
            _accessModifier = AccessModifierType.Public;
            return this;
        }

        public TypeDefinitionBuilder AddFunction(Func<FunctionDefinitionBuilder,FunctionDefinitionBuilder> functionConfigurator)
        {
            _functionDefinitionBuilders.Add(functionConfigurator (FunctionDefinitionBuilder.Create()));
            return this;
        }

        public TypeDefinition Build()
        {
            if (_accessModifier == AccessModifierType.Undefined)
                throw new MalformedDefinitionException ("No access modifier has been defined for this class.");

            if(string.IsNullOrEmpty (_className)) {
                throw new MalformedDefinitionException ("No name has been set for this class definition.");
            }

            if(string.IsNullOrEmpty (_namespace)) {
                throw new MalformedDefinitionException ("No namespace has been set for this class definition.");
            }

            var functionDefinitions = _functionDefinitionBuilders.Select (f => f.Build ());
            return new TypeDefinition(_accessModifier,_className, _namespace, functionDefinitions);
        }
    }
}
