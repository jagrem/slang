using slang.Lexing.Rules.Core;

namespace slang.Lexing.Trees.Transformers
{
    public static class RuleExtensions
    {
        public static Tree Transform(this Rule rule)
        {
            if (rule is Or) {
                return (rule as Or).Transform ();
            }

            if (rule is And) {
                return (rule as And).Transform ();
            }

            if (rule is Repeat) {
                return (rule as Repeat).Transform ();
            }

            return (rule as Constant).Transform ();
        }
    }
}
