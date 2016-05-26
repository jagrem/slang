using slang.Lexing.Rules.Core;

namespace slang.Lexing.Rules.Extensions
{
    public class Option : Rule, IComplexRule
    {
        public Rule Value { get; set; }

        public Option (Rule option)
        {
            Value = option;
        }

        public Rule Transform()
        {
            return new Or (Value, new Empty ());
        }
    }
}

