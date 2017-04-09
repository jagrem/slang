using System.Collections.Generic;

namespace slang.Compiler.Clr.Compilation.Definitions
{
    public class TypeDefinition
    {
        public AccessModifierType AccessModifier { get; }
        public string Name { get; }
        public string Namespace { get; }
        public IEnumerable<FunctionDefinition> FunctionDefinitions { get; }

        public TypeDefinition(AccessModifierType accessModifier, string name, string @namespace, IEnumerable<FunctionDefinition> functionDefinitions)
        {
            AccessModifier = accessModifier;
            Name = name;
            Namespace = @namespace;
            FunctionDefinitions = functionDefinitions;
        }
    }
}
