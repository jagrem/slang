namespace slang.Lexing.Rules
{
    public class Repeat : Rule
    {
        public Rule Value { get; set; }

        public Repeat (Rule value)
        {
            Value = value;
        }
    }
}

