using System;
using System.Linq;
using System.Collections.Generic;

namespace slang.Compiler.Clr.Compilation.Definitions.Builders
{
    public class AssemblyDefinitionBuilder
    {
        enum ExtensionType { None, Executable, Library }

        string _assemblyName;
        readonly List<ModuleDefinitionBuilder> _moduleDefinitionBuilders = new List<ModuleDefinitionBuilder>();
        ExtensionType _extensionType = ExtensionType.None;

        AssemblyDefinitionBuilder()
        {
        }
            
        public static AssemblyDefinitionBuilder Create(string name)
        {
            return new AssemblyDefinitionBuilder ()
                .WithAssemblyName (name);
        }

        public AssemblyDefinitionBuilder WithAssemblyName(string assemblyName)
        {
            _assemblyName = assemblyName;
            return this;
        }

        public AssemblyDefinitionBuilder AsExecutable()
        {
            _extensionType = ExtensionType.Executable;
            return this;
        }

        public AssemblyDefinitionBuilder AsLibrary()
        {
            _extensionType = ExtensionType.Library;
            return this;
        }

        public AssemblyDefinitionBuilder AddModule(Func<ModuleDefinitionBuilder,ModuleDefinitionBuilder> moduleDefinitionConfigurator)
        {
            _moduleDefinitionBuilders.Add(moduleDefinitionConfigurator(ModuleDefinitionBuilder.Create()));
            return this;
        }

        public AssemblyDefinition Build()
        {
            if(_extensionType == ExtensionType.None) {
                throw new MalformedDefinitionException ("You must choose whether the assembly is an executable or a library.");
            }

            return new AssemblyDefinition(
                _assemblyName,
                _moduleDefinitionBuilders.Select(moduleDefinitionBuilder => moduleDefinitionBuilder.Build()));
        }
    }
}
