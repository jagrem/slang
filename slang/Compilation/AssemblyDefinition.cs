using System.Collections.Generic;

namespace slang.Compilation
{
    public class AssemblyDefinition
    {
        public AssemblyDefinition()
        {
            Modules = new ModuleDefinition[0];   
        }

        public string Name { get; set; }
        public string Filename { get; set; }
        public IEnumerable<ModuleDefinition> Modules { get; set; }
    }
}

