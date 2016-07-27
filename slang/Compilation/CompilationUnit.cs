namespace slang.Compilation
{
    public class CompilationUnit
    {
        public CompilationUnit (string sourceFilename)
        {
            SourceFile = sourceFilename;
        }

        public string SourceFile { get; set; }
    }
}

