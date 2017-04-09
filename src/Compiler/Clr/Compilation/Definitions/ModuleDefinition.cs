using System.Collections.Generic;

namespace slang.Compiler.Clr.Compilation.Definitions
{
    public class ModuleDefinition
    {
        public string Name { get; }
        public string FileName { get; }
        public IEnumerable<TypeDefinition> ClassDefinitions { get; }

        public ModuleDefinition (string name, string fileName, IEnumerable<TypeDefinition> classDefinitions)
        {
            Name = name;
            FileName = fileName;
            ClassDefinitions = classDefinitions;
        }
    }
}
