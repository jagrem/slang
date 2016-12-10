using System.Collections.Generic;

namespace slang.Compiler.Clr.Compilation.Definitions
{
    public class ClassDefinition
    {
        public AccessModifierType AccessModifier { get; set; }
        public string Name { get; set; }
        public string Namespace { get; set; }
        public IEnumerable<FunctionDefinition> FunctionDefinitions { get; set; }

        public ClassDefinition(AccessModifierType accessModifier, string name, string @namespace, IEnumerable<FunctionDefinition> functionDefinitions)
        {
            AccessModifier = accessModifier;
            Name = name;
            Namespace = @namespace;
            FunctionDefinitions = functionDefinitions;
        }
    }
}
