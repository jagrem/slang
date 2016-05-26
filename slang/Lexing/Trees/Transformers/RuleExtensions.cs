using System.Collections.Generic;
using System.Linq;
using slang.Lexing.Rules.Core;
using slang.Lexing.Rules.Extensions;
using slang.Lexing.Trees.Nodes;

namespace slang.Lexing.Trees.Transformers
{
    public static class RuleExtensions
    {
        public static LexicalNode Transform (this Rule rule, LexicalNode parent)
        {
            return rule.Transform (new [] { parent });
        }

        public static LexicalNode Transform (this Rule rule, IEnumerable<LexicalNode> parents)
        {
            if (rule is IComplexRule) {
                // Transform into less complex parts
            }

            if (rule is Or) {
                return Transform (rule as Or, parents.Single ());
            }

            if (rule is And) {
                return Transform (rule as And, parents.Single ());
            }

            return Transform (rule as Constant, parents);
        }
    }
}
