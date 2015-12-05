using System.Collections.Generic;
using System;
using System.Linq;
using slang.Lexing.Transitions.Numbers;
using slang.Lexing.Tokens;
using slang.Lexing.Transitions;

namespace slang.Lexing
{
    public static class Lexer
    {
        static readonly Dictionary<State,Func<LexerState,LexerState>> transitions = BasicTransitions.Transitions
            .Concat (Number.Transitions)
            .Concat (HexadecimalInteger.Transitions)
            .Concat (DecimalInteger.Transitions)
            .Concat (Punctuation.Transitions)
            .Concat (Keywords.Transitions)
            .ToDictionary (p => p.Key, p => p.Value);
        
        public static IEnumerable<Token> Analyze(string input)
        {
            return Scan (input).Where (t => t != Token.Empty);
        }

        static IEnumerable<Token> Scan(string input) {
            yield return new Start ();

            var buffer = input.ToCharArray ();
            var state = new LexerState { Token = Token.Empty, State = State.Zero, Buffer = string.Empty, Value = (char)0 };

            foreach (char c in buffer) {
                state.Value = c;

                if(transitions.ContainsKey (state.State)) {
                    state = transitions [state.State] (state);
                    yield return state.Token;
                }
            }

            // EOF 
            if(transitions.ContainsKey (state.State)) {
                state.Value = (char)0;
                state = transitions [state.State] (state);
                yield return state.Token;
            }

            yield return new End();
        }
    }
}

