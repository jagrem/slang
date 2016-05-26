using slang.Lexing.Rules.Core;
using slang.Lexing.Trees.Nodes;

namespace slang.Lexing.Trees.Transformers
{
    public static class OrRuleExtensions
    {
        public static Node Transform (this Or rule, Node parent)
        {
            rule.Left.Transform (parent);
            rule.Right.Transform (parent);
            return parent;
        }
    }
}

