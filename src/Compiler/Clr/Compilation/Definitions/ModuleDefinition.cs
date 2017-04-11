using System.Collections.Generic;

namespace slang.Compiler.Clr.Compilation.Definitions
{
    public class ModuleDefinition
    {
        public string Name { get; }
        public string Namespace { get; }
        public IEnumerable<TypeDefinition> TypeDefinitions { get; }
        public IEnumerable<FunctionDefinition> FunctionDefinitions { get; }

        public ModuleDefinition (string name, string @namespace, IEnumerable<TypeDefinition> typeDefinitions, IEnumerable<FunctionDefinition> functionDefinitions)
        {
            Name = name;
            Namespace = @namespace;
            TypeDefinitions = typeDefinitions;
            FunctionDefinitions = functionDefinitions;
        }
    }
}
