using System;
using System.Collections.Generic;
using System.Linq;

namespace slang.Compilation
{
    public class AssemblyDefinitionBuilder
    {
        enum ExtensionType { Executable, Library }

        string _assemblyName;
        readonly List<ClassDefinitionBuilder> _classDefinitionBuilders = new List<ClassDefinitionBuilder>();
        ExtensionType _extensionType = ExtensionType.Executable;

        AssemblyDefinitionBuilder()
        {
        }
            
        public static AssemblyDefinitionBuilder Create(string name)
        {
            return new AssemblyDefinitionBuilder ().WithAssemblyName (name);
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
            _classDefinitionBuilders.Add(classDefinitionConfigurator(new ClassDefinitionBuilder ()));
            return this;
        }

        public AssemblyDefinition Build()
        {           
            var assemblyFilename = _assemblyName + (_extensionType == ExtensionType.Executable ? ".exe" : ".dll");
            var classDefinitions = _classDefinitionBuilders.Select (c => c.Build ());
            return new AssemblyDefinition { 
                Name = _assemblyName,
                Filename = assemblyFilename,
                Modules =  new[] { 
                    new ModuleDefinition(_assemblyName, assemblyFilename, classDefinitions) } };
        }
    }
}

