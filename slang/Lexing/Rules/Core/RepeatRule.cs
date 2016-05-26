namespace slang.Lexing.Rules.Core
{
    public class RepeatRule : Rule
    {
        public Rule Value { get; set; }

        public RepeatRule (Rule value)
        {
            Value = value;
        }
    }
}

