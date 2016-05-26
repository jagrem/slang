using slang.Lexing.Rules.Core;

namespace slang.Lexing.Rules.Extensions
{
    public class Option : Rule
    {
        public Rule Value { get; set; }

        public Option (Rule option)
        {
            Value = option;
        }
    }
}

