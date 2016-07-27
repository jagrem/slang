using System;

namespace slang.Compiler.Clr.Compilation.Definitions
{
    public class MalformedDefinitionException : Exception
    {
        public MalformedDefinitionException (string message) : base (message) { }
    }
}
