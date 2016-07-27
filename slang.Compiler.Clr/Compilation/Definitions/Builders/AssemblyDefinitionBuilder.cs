using System;
using System.Collections.Generic;
using System.Linq;

namespace slang.Compiler.Clr.Compilation.Definitions.Builders
{
    public class AssemblyDefinitionBuilder
    {
        enum ExtensionType { None, Executable, Library }

        string _assemblyName;
        readonly List<ClassDefinitionBuilder> _classDefinitionBuilders = new List<ClassDefinitionBuilder>();
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

        public AssemblyDefinitionBuilder AddClass(Func<ClassDefinitionBuilder, ClassDefinitionBuilder> classDefinitionConfigurator)
        {
            _classDefinitionBuilders.Add(classDefinitionConfigurator(ClassDefinitionBuilder.Create()));
            return this;
        }

        public AssemblyDefinition Build()
        {
            if(_extensionType == ExtensionType.None) {
                throw new MalformedDefinitionException ("You must choose whether the assembly is an executable or a library.");
            }

            var assemblyFilename = _assemblyName + (_extensionType == ExtensionType.Executable ? ".exe" : ".dll");
            var classDefinitions = _classDefinitionBuilders.Select (c => c.Build ());
            return new AssemblyDefinition(
                _assemblyName,
                assemblyFilename,
                new[] { new ModuleDefinition(_assemblyName, assemblyFilename, classDefinitions) });
        }
    }
}
