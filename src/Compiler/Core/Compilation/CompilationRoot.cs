using System.Collections.Generic;

namespace slang.Compiler.Core.Compilation
{
    public class CompilationRoot
    {
        public IEnumerable<CompilationUnit> CompilationUnits { get; private set; }

        public CompilationRoot (IEnumerable<CompilationUnit> compilationUnits)
        {
            CompilationUnits = compilationUnits;
        }
    }
}
