using System.Collections.Generic;

namespace slang.Compilation
{
    public class ClassDefinition
    {
        public AccessModifierType AccessModifier { get; set; }
        public string Name { get; set; }
        public string Namespace { get; set; }
        public IEnumerable<FunctionDefinition> FunctionDefinitions { get; set; }
    }
}

