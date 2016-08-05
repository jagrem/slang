using System.Collections.Generic;

namespace slang.Compiler.Core.Compilation
{
    public class CompilationUnit
    {
        public string Name { get; private set; }
        public CompilationMetadata Metadata { get; private set; }
        public IEnumerable<string> SourceFiles { get; private set; }

        public CompilationUnit (string name, CompilationMetadata metadata, IEnumerable<string> sourceFilenames)
        {
            Name = name;
            Metadata = metadata;
            SourceFiles = sourceFilenames;
        }
    }
}

