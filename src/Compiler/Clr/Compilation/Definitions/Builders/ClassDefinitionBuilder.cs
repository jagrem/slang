using System;
using System.Collections.Generic;
using System.Linq;

namespace slang.Compiler.Clr.Compilation.Definitions
{
    public class ClassDefinitionBuilder
    {
        string _className;
        string _namespace;
        AccessModifierType _accessModifier;
        readonly List<FunctionDefinitionBuilder> _functionDefinitionBuilders = new List<FunctionDefinitionBuilder>();

        ClassDefinitionBuilder() {}

        public static ClassDefinitionBuilder Create()
        {
            return new ClassDefinitionBuilder ();
        }

        public ClassDefinitionBuilder WithName(string className)
        {
            _className = className;   
            return this;
        }

        public ClassDefinitionBuilder WithNamespace(string @namespace)
        {
            _namespace = @namespace;
            return this;
        }

        public ClassDefinitionBuilder Public()
        {
            _accessModifier = AccessModifierType.Public;
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

            if(string.IsNullOrEmpty (_className)) {
                throw new MalformedDefinitionException ("No name has been set for this class definition.");
            }

            if(string.IsNullOrEmpty (_namespace)) {
                throw new MalformedDefinitionException ("No namespace has been set for this class definition.");
            }
 
            var functionDefinitions = _functionDefinitionBuilders.Select (f => f.Build ());
            return new ClassDefinition(_accessModifier,_className, _namespace, functionDefinitions);
        }
    }
}

