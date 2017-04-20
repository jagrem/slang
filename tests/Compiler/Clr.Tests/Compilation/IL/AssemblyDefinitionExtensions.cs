using System;
using System.Reflection;
using slang.Compiler.Clr.Compilation.Definitions;

namespace slang.Tests.IL
{

    static class AssemblyDefinitionExtensions
    {
        public static Type [] GetTypes (this AssemblyDefinition assemblyDefinition)
        {
            return assemblyDefinition.LoadAssembly ().GetTypes ();
        }

        public static Assembly LoadAssembly (this AssemblyDefinition assemblyDefinition)
        {
            throw new InvalidOperationException("We will no longer be loading dynamic assemblies for disk so this operation is no longer possible.");
        }
    }    
}
