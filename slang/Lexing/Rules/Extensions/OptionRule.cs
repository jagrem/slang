using slang.Lexing.Rules.Core;

namespace slang.Lexing.Rules.Extensions
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

