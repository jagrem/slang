namespace slang.Lexing.Rules.Core
{
    public abstract class Rule
    {
        public static Rule operator | (Rule left, Rule right)
        {
            return new Or (left, right);
        }

        public static Rule operator + (Rule left, Rule right)
        {
            return new And (left, right);
        }

        public static implicit operator Rule (char value)
        {
            return new Constant (value);
        }
    }
}
