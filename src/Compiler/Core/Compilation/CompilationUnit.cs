using System.Collections.Generic;

namespace slang.Compiler.Core.Compilation
{
    public class CompilationUnit
    {
        public CompilationMetadata Metadata { get; private set; }
        public IEnumerable<string> SourceFiles { get; private set; }

        public CompilationUnit (CompilationMetadata metadata, IEnumerable<string> sourceFilenames)
        {
            Metadata = metadata;
            SourceFiles = sourceFilenames;
        }
    }
}

