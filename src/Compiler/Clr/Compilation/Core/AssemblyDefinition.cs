using System.Collections.Generic;

namespace slang.Compiler.Clr.Compilation.Core
{
    public class AssemblyDefinition
    {
        public string Name { get; }
        public IEnumerable<ModuleDefinition> Modules { get; }

        public AssemblyDefinition (string name, IEnumerable<ModuleDefinition> modules)
        {
            Name = name;
            Modules = modules;
        }
    }
}
