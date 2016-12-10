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
            return AppDomain.CurrentDomain.Load (new AssemblyName (assemblyDefinition.Name));
        }
    }    
}
