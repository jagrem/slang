namespace slang.Compiler.Core.Compilation
{
    public class CompilationMetadata
    {
        public CompilationMetadata(string projectName)
        {
            ProjectName = projectName;
        }

        public string ProjectName { get; set; }
    }
}

