using slang.Lexing.Rules.Core;
using slang.Lexing.Trees.Nodes;

namespace slang.Lexing.Trees.Transformers
{
    public static class OrRuleExtensions
    {
        public static LexicalNode Transform (this Or rule, LexicalNode parent)
        {
            rule.Left.Transform (parent);
            rule.Right.Transform (parent);
            return parent;
        }
    }
}

