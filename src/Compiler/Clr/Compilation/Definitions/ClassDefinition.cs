using System.Collections.Generic;

namespace slang.Compiler.Clr.Compilation.Definitions
{
    public class ClassDefinition
    {
        public AccessModifierType AccessModifier { get; }
        public string Name { get; }
        public string Namespace { get; }
        public IEnumerable<FunctionDefinition> FunctionDefinitions { get; }

        public ClassDefinition(AccessModifierType accessModifier, string name, string @namespace, IEnumerable<FunctionDefinition> functionDefinitions)
        {
            AccessModifier = accessModifier;
            Name = name;
            Namespace = @namespace;
            FunctionDefinitions = functionDefinitions;
        }
    }
}
