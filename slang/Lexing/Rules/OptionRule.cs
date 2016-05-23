namespace slang.Lexing.Rules
{
    public class OptionRule : Rule
    {
        public Rule Option { get; set; }

        public OptionRule (Rule option)
        {
            Option = option;
        }
    }
}

