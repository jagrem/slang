using slang.AST;

namespace slang.Compilation
{
    public class CompilationUnit
    {
        public CompilationUnit (string sourceFilename, ProgramNode root)
        {
            SourceFile = sourceFilename;
            Root = root;
        }

        public string SourceFile { get; set; }

        public ProgramNode Root { get; set; }
    }
}

