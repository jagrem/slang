using System.Collections.Generic;
using slang.Lexing.Rules.Core;
using slang.Lexing.Tokens;
using slang.Lexing.Trees;
using slang.Lexing.Trees.Nodes;
using System.Linq;
using System;

namespace slang.Lexing
{
    public class Lexer2
    {
        readonly Node root;

        public Lexer2 (Rule rule)
        {
            root = TreeBuilder.Build (rule).Root;
        }

        public IEnumerable<Token> Scan(string input)
        {
            return ScanInternal (input).Where (token => token != null);
        }

        IEnumerable<Token> ScanInternal(string input)
        {
            var current = root;

            foreach (char c in input) {
                var character = Character.FromChar (c);

                if (current.Transitions.ContainsKey (character)) {
                    var transition = current.Transitions [character];
                    yield return transition.GetToken ();
                    current = transition.Target;
                } else {
                    if(current.Transitions.ContainsKey (Character.Any)) {
                        var transition = current.Transitions [Character.Any];
                        yield return transition.GetToken ();

                        if(transition.Target != null) {
                            current = transition.Target;
                        } else {
                            current = root;
                        }
                    } else {
                        current = root;
                    }

                    if (current.Transitions.ContainsKey (character)) {
                        var transition = current.Transitions [character];
                        yield return transition.GetToken ();
                        current = transition.Target;
                    }
                }
            }

            // EOF
            if (current.Transitions.ContainsKey (Character.Any)) yield return current.Transitions [Character.Any].GetToken ();
        }
    }
}

