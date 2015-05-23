using System;
using System.Collections.Generic;
using System.Linq;

namespace slang.Compilation
{
    public class ClassDefinitionBuilder
    {
        string _className;
        AccessModifierType _accessModifier;
        readonly List<FunctionDefinitionBuilder> _functionDefinitionBuilders = new List<FunctionDefinitionBuilder>();

        public ClassDefinitionBuilder WithName(string className)
        {
            _className = className;   
            return this;
        }

        public ClassDefinitionBuilder Public()
        {
            _accessModifier = AccessModifierType.Public;
            return this;
        }

        public ClassDefinitionBuilder Internal()
        {
            _accessModifier = AccessModifierType.Internal;
            return this;
        }

        public ClassDefinitionBuilder Private()
        {
            _accessModifier = AccessModifierType.Private;
            return this;
        }

        public ClassDefinitionBuilder AddFunction(Func<FunctionDefinitionBuilder,FunctionDefinitionBuilder> functionConfigurator)
        {
            _functionDefinitionBuilders.Add(functionConfigurator (new FunctionDefinitionBuilder ()));
            return this;
        }

        public ClassDefinition Build()
        {
            if (_accessModifier == AccessModifierType.Undefined)
                throw new MalformedDefinitionException ("No access modifier has been defined for this class.");

            var functionDefinitions = _functionDefinitionBuilders.Select (f => f.Build ());
            return new ClassDefinition { Name = _className, AccessModifier = _accessModifier, FunctionDefinitions = functionDefinitions };
        }
    }

    public enum AccessModifierType { Undefined, Public, Private, Internal, Protected }

    public class MalformedDefinitionException : Exception
    {
        public MalformedDefinitionException(string message) : base(message) { }
    }
}

