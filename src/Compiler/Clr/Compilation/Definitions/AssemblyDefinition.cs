using System.Collections.Generic;

namespace slang.Compiler.Clr.Compilation.Definitions
{
    public class AssemblyDefinition
    {
        public string Name { get; }
        public string Filename { get; }
        public IEnumerable<ModuleDefinition> Modules { get; }

        public AssemblyDefinition (string name, string filename, IEnumerable<ModuleDefinition> modules)
        {
            Name = name;
            Filename = filename;
            Modules = modules;
        }
    }
}
