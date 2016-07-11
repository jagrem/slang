using slang.Lexing.Rules.Extensions;
using slang.Lexing.Trees.Nodes;

namespace slang.Lexing.Trees.Transformers
{
    public static class OptionRuleExtensions
    {
        public static Tree Transform (this Option rule, Node parent)
        {
            return new Tree ();
        }
    }
}
