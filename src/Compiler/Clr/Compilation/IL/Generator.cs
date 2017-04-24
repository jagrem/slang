using System;
using slang.Compiler.Clr.Compilation.Definitions;

namespace slang.Compiler.Clr.Compilation.IL
{
    public static class Generator
    {
        public static void GenerateAssembly(AssemblyDefinition assemblyDefinition)
        {
            throw new NotSupportedException("IL generation is somewhat flawed on the .NET Core platform so we will avoid it for the moment.");
        }
    }
}

