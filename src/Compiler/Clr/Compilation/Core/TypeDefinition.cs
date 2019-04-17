using System.Collections.Generic;

namespace slang.Compiler.Clr.Compilation.Core
{
    public class TypeDefinition
    {
        public AccessModifierType AccessModifier { get; }
        public string Name { get; }
        public string Namespace { get; }
        public IEnumerable<FunctionDefinition> FunctionDefinitions { get; } //TODO: Change this to a collection of properties

        public TypeDefinition(AccessModifierType accessModifier, string name, string @namespace, IEnumerable<FunctionDefinition> functionDefinitions)
        {
            AccessModifier = accessModifier;
            Name = name;
            Namespace = @namespace;
            FunctionDefinitions = functionDefinitions;
        }
    }
}
