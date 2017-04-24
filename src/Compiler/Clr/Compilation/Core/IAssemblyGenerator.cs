using slang.Compiler.Clr.Compilation.Definitions;

namespace slang.Compiler.Clr.Compilation
{
    public interface IAssemblyGenerator
    {
        void GenerateDynamicAssembly(AssemblyDefinition assemblyDefinition);
    }
}
