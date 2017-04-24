using System;
using System.Reflection;
using slang.Compiler.Clr.Compilation.Core;

namespace slang.Compiler.Clr.Compilation.IL
{
    public class MsilAssemblyGenerator : IAssemblyGenerator
    {
        public Assembly GenerateDynamicAssembly(AssemblyDefinition assemblyDefinition)
        {
            throw new NotSupportedException("IL generation is somewhat flawed on the .NET Core platform so we will avoid it for the moment.");
        }
    }
}
