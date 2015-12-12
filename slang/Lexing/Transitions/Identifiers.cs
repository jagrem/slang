using System.Collections.Generic;
using System;

namespace slang.Lexing.Transitions
{
    public static class Identifiers
    {
        public static readonly Dictionary<State,Func<LexerState,LexerState>> Transitions = new Dictionary<State,Func<LexerState,LexerState>>
        {
        };
    }
}

