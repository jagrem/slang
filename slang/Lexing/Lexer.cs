using System.Collections.Generic;
using slang.Lexing.Rules;
using slang.Lexing.Tokens;
using slang.Lexing.Trees;
using slang.Lexing.Trees.Nodes;
using System.Linq;

namespace slang.Lexing
{
    public class Lexer
    {
        readonly TreeNode root;

        public Lexer (Rule rule)
        {
            root = TreeBuilder.Build (rule).Root;
        }

        public IEnumerable<Token> Scan(string input)
        {
            return ScanInternal (input).Where (token => token != null);
        }

        public override string ToString()
        {
            return TreeDescriber.Describe(root);
        }

        IEnumerable<Token> ScanInternal(string input)
        {
            var current = root;
            var context = string.Empty;

            foreach (char c in input) {
                
                var character = Character.FromChar (c);

                if (current.Transitions.ContainsKey (character)) {
                    context += c;
                    var transition = current.Transitions [character];
                    var token = transition.GetToken (context);
                    if (token != null) context = string.Empty;
                    yield return token;
                    current = transition.Target;
                } else {
                    if(current.Transitions.ContainsKey (Character.Any)) {
                        var transition = current.Transitions [Character.Any];
                        var token = transition.GetToken (context);
                        if (token != null) context = string.Empty;
                        yield return token;

                        if(transition.Target != null) {
                            current = transition.Target;
                        } else {
                            current = root;
                        }
                    } else {
                        current = root;
                    }

                    if (current.Transitions.ContainsKey (character)) {
                        context += c;
                        var transition = current.Transitions [character];
                        var token = transition.GetToken (context);
                        if (token != null) context = string.Empty;
                        yield return token;
                        current = transition.Target;
                    }
                }
            }

            // EOF
            if (current.Transitions.ContainsKey (Character.Any)) {
                yield return current.Transitions [Character.Any].GetToken (context);   
            }
        }
    }
}

