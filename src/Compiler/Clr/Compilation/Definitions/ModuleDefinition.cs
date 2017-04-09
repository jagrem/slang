using System.Collections.Generic;

namespace slang.Compiler.Clr.Compilation.Definitions
{
    public class ModuleDefinition
    {
        public string Name { get; }
        public string FileName { get; }
        public IEnumerable<ClassDefinition> ClassDefinitions { get; }

        public ModuleDefinition (string name, string fileName, IEnumerable<ClassDefinition> classDefinitions)
        {
            Name = name;
            FileName = fileName;
            ClassDefinitions = classDefinitions;
        }
    }
}
