using slang.Lexing.Rules.Core;

namespace slang.Lexing.Rules.Extensions
{
    public class Star : Rule
    {
        public Rule Value { get; set; }

        public Star (Rule value)
        {
            Value = value;
        }
    }
}

