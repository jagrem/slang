using System;
using System.Collections.Generic;
using slang.Lexing.Extensions;
using slang.Lexing.Tokens.Literals;

namespace slang.Lexing.Transitions.Numbers
{
    static class HexadecimalInteger
    {
        public static readonly Dictionary<State,Func<LexerState,LexerState>> Transitions = new Dictionary<State,Func<LexerState,LexerState>> {
            {
                // "0" "x" ^
                State.S_number_and_hexadecimal_specifier, 
                s => {
                    if(s.Value.IsHexadecimalDigit ()) return s.TransitionTo (State.S_hexadecimal_number);
                    return s.ToError ();
                }
            },
            {
                // "0" "x" digit ^
                State.S_hexadecimal_number, 
                s => {
                    if(s.Value.IsHexadecimalDigit ()) return s.TransitionTo (State.S_hexadecimal_number);
                    if(s.Value.IsEnd()) return s.Returns(new IntegerLiteral (s.Buffer));
                    if(s.Value.IsLongSpecifier ()) return s.TransitionTo (State.S_number_with_integer_specifier, s.Buffer);
                    if(s.Value.IsUnsignedSpecifier ()) return s.TransitionTo (State.S_number_with_unsigned_specifier, s.Buffer);
                    return s.ToError ();
                }
            },
        };
    }
}

