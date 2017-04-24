using System;
using slang.Compiler.Clr.Compilation.Definitions;

namespace slang.Compiler.Clr.Compilation.IL
{
    public class MsilGenerator : IAssemblyGenerator
    {
        public void GenerateDynamicAssembly(AssemblyDefinition assemblyDefinition)
        {
            throw new NotSupportedException("IL generation is somewhat flawed on the .NET Core platform so we will avoid it for the moment.");
        }
    }
}

