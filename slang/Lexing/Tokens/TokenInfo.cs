namespace slang.Lexing.Tokens
{
    public class TokenInfo
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public TokenInfo (string name, string value)
        {
            Value = value;
            Name = name;
        }
    }
}

