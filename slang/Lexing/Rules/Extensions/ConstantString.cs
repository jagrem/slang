using slang.Lexing.Rules.Core;

namespace slang.Lexing.Rules.Extensions
{
    public class ConstantString : Rule
    {
        public ConstantString (string value)
        {
            Value = value;
        }

        public string Value { get; private set; }
    }
}

