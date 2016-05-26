using slang.Lexing.Rules.Extensions;
using slang.Lexing.Trees.Nodes;

namespace slang.Lexing.Trees.Transformers
{
    public static class OptionRuleExtensions
    {
        public static Node Transform (this Option rule, Node parent)
        {
            var option = rule.Value.Transform (parent);
            return option;
        }
    }
}
