using System.Collections.Generic;

namespace slang.Compilation
{
    public class CompilationRoot
    {
        public CompilationRoot (CompilationMetadata metadata)
        {
            CompilationUnits = new List<CompilationUnit> ();
            Metadata = metadata;
        }

        public List<CompilationUnit> CompilationUnits { get; private set; }

        public CompilationMetadata Metadata { get; private set; }
    }
}

