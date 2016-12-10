namespace slang.Compiler.Core.Compilation
{
    public class CompilationMetadata
    {
        public string Name { get; private set; }
        public string Namespace { get; private set; }
        public AssemblyType AssemblyType { get; private set; }

        public CompilationMetadata(string name, string @namespace, AssemblyType assemblyType)
        {
            Name = name;
            Namespace = @namespace;
            AssemblyType = assemblyType;
        }
    }
}

