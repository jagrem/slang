using System.Collections.Generic;
using System.Linq;
using slang.Lexing.Transitions.Numbers;
using System;

namespace slang.Lexing.Transitions
{
    class Transition
    {
        public char Character { get; set; }
        public string FromState { get; set; }
        public string ToState { get; set; }

        public static Dictionary<State,Func<LexerState,LexerState>> GetTransitions()
        {
            return Zero.Transitions
                .Concat (DecimalInteger.Transitions)
                .Concat (HexadecimalInteger.Transitions)
                .Concat (Number.Transitions)
                .Concat (Real.Transitions)
                .Concat (Punctuation.Transitions)
                .Concat (Keywords.Transitions)
                .ToDictionary (t => t.Key, t => t.Value);
        }
    }
}
