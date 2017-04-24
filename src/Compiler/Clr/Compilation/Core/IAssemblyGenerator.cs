namespace slang.Compiler.Clr.Compilation.Core
{
    public interface IAssemblyGenerator
    {
        void GenerateDynamicAssembly(AssemblyDefinition assemblyDefinition);
    }
}
