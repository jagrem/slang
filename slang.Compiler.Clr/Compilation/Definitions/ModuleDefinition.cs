using System.Collections.Generic;

namespace slang.Compiler.Clr.Compilation.Definitions
{
    public class ModuleDefinition
    {
        public string Name { get; private set; }
        public string FileName { get; private set; }
        public IEnumerable<ClassDefinition> ClassDefinitions { get; private set;}

        public ModuleDefinition (string name, string fileName, IEnumerable<ClassDefinition> classDefinitions)
        {
            Name = name;
            FileName = fileName;
            ClassDefinitions = classDefinitions;
        }
    }
}
