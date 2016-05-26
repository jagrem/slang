using slang.Lexing.Rules.Extensions;
using slang.Lexing.Trees.Nodes;

namespace slang.Lexing.Trees.Transformers
{
    public static class OptionRuleExtensions
    {
        public static LexicalNode Transform (this Option rule, LexicalNode parent)
        {
            var option = rule.Value.Transform (parent);
            return option;
        }
    }
}
