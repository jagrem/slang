namespace slang.Lexing.Rules.Core
{
    public class Constant : Rule
    {
        public char Value { get; set; }

        public Constant (char value)
        {
            Value = value;
        }
    }
}

