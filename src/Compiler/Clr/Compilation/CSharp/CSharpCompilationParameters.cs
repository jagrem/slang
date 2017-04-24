using slang.Compiler.Clr.Compilation.Core;

namespace slang.Compiler.Clr.Compilation.CSharp
{
    public class CSharpCompilationParameters
    {
        public string AssemblyName { get; }
        public OutputType OutputType { get; }
        public string SourceCode { get; }

        public CSharpCompilationParameters(string assemblyName, OutputType outputType, string sourceCode)
        {
            AssemblyName = assemblyName;
            OutputType = outputType;
            SourceCode = sourceCode;
        }
    }
}
