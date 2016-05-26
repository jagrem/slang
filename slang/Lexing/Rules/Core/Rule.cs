namespace slang.Lexing.Rules.Core
{
    public abstract class Rule
    {
        public static Rule operator | (Rule left, Rule right)
        {
            return new OrRule (left, right);
        }

        public static Rule operator + (Rule left, Rule right)
        {
            return new AndRule (left, right);
        }

        public static implicit operator Rule (char value)
        {
            return new ConstantRule (value);
        }
    }
}
