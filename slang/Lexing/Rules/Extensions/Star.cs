using slang.Lexing.Rules.Core;

namespace slang.Lexing.Rules.Extensions
{
    public class Star : Rule, IComplexRule
    {
        public Rule Value { get; set; }

        public Star (Rule value)
        {
            Value = value;
        }

        public Rule Transform() 
        {
            return new Or (new Repeat (Value), new Empty ());
        }
    }
}

