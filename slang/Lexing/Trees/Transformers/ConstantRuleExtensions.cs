using slang.Lexing.Rules.Core;
using slang.Lexing.Trees.Nodes;

namespace slang.Lexing.Trees.Transformers
{
    public static class ConstantRuleExtensions
    {
        public static Tree Transform(this Constant rule)
        {
            var root = new Node ();
            var key = Character.FromChar (rule.Value);
            var value = new Node ();
            value.Transitions.Add (Character.Any, new Transition (null, rule.TokenCreator));
            root.Transitions.Add (key, new Transition(value));
            return new Tree (root);
        }
    }
}
