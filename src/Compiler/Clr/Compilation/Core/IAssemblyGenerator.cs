using System.Reflection;

namespace slang.Compiler.Clr.Compilation.Core
{
    public interface IAssemblyGenerator
    {
        Assembly GenerateDynamicAssembly(AssemblyDefinition assemblyDefinition);
    }
}
