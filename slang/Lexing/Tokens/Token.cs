namespace slang.Lexing.Tokens
{
    public abstract class Token
    {
        public string Value { get; protected set; }

        public override string ToString ()
        {
            return string.Format ("[{0}: \"{1}\"]", this.GetType ().Name, Value);
        }

        public static Token Empty { get { return null; } }
    }
}

