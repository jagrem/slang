namespace slang.Lexing.Rules.Core
{
    public class Constant : Rule
    {
        public string Value { get; set; }

        public Constant (char value)
        {
            Value = new string (new char [] { value });
        }

        public Constant(string value)
        {
            Value = value;
        }
    }
}

