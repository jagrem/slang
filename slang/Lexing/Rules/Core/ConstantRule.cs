namespace slang.Lexing.Rules.Core
{
    public class ConstantRule : Rule
    {
        public char Value { get; set; }

        public ConstantRule (char value)
        {
            Value = value;
        }
    }
}

