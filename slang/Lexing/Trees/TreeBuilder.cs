using System.Collections.Generic;
using System.Linq;
using slang.Lexing.Rules.Core;
using slang.Lexing.Trees.Nodes;
using slang.Lexing.Trees.Transformers;

namespace slang.Lexing.Trees
{
    public static class TreeBuilder
    {
        public static Tree Build (Rule rule)
        {
            return rule.Transform ();
        }

        public static IEnumerable<Node> GetLeafNodes (Node node)
        {
            if(!node.Transitions.Any () 
               || (
                   node.Transitions.Count () == 1 
                   && node.Transitions.ElementAt (0).Key == Character.Any
                  )
              ) 
            {
                return new [] { node };
            }

            return node
                .Transitions
                .SelectMany (n => {
                    if (n.Value.Target == null) {
                        return new Node [0];
                    }

                    if (!n.Value.Target.Transitions.Any ()) {
                        return new [] { n.Value.Target };
                    }

                    return GetLeafNodes (n.Value.Target);
                });
        }
    }
}

