using System.Collections.Generic;
using System;

namespace slang.Lexing.Transitions.Text
{
    public static class Strings
    {
        public static readonly Dictionary<State,Func<LexerState,LexerState>> Transitions = new Dictionary<State,Func<LexerState,LexerState>> {
        };
    }
}

