using System.Collections.Generic;

namespace slang.Compiler.Clr.Compilation.Definitions
{
    public class AssemblyDefinition
    {
        public string Name { get; private set; }
        public string Filename { get; private set; }
        public IEnumerable<ModuleDefinition> Modules { get; private set; }

        public AssemblyDefinition (string name, string filename, IEnumerable<ModuleDefinition> modules)
        {
            Name = name;
            Filename = filename;
            Modules = modules;
        }
    }
}
