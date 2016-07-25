namespace slang.Lexing.Rules
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
