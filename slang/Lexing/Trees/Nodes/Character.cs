namespace slang.Lexing.Trees.Nodes
{
    public class Character
    {
        static readonly Character _any = new Character ((char)0);

        public static Character Any { get { return _any; } }

        public char Value { get; }

        public Character (char value)
        {
            Value = value;
        }

        public static Character FromChar(char c) {
            return new Character (c);
        }

        public static implicit operator Character (char c)
        {
            return new Character (c);
        }

        public override bool Equals (object obj)
        {
            var character = obj as Character;

            if (character == null) return false;

            if (character == _any && this == _any) return true;

            return Value == character.Value;
        }

        public override int GetHashCode ()
        {
            return Value.GetHashCode ();
        }
    }
}

