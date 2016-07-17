namespace slang.Lexing.Tokens
{
    public abstract class Token
    {
        protected Token(string value) {
            Value = value;
        }

        public string Value { get; private set; }

        public override string ToString ()
        {
            return string.Format ("[{0}: \"{1}\"]", this.GetType ().Name, Value);
        }

        public override bool Equals (object obj)
        {
            if (obj == null || !(obj is Token)) return false;
            return Value.Equals (((Token)obj).Value);
        }

        public override int GetHashCode ()
        {
            return Value.GetHashCode ();
        }

        public static Token Empty { get { return null; } }
    }
}

