using System;

namespace slang.Compiler.Clr.Compilation.Core
{
    public class MalformedDefinitionException : Exception
    {
        public MalformedDefinitionException (string message) : base (message) { }
    }
}
