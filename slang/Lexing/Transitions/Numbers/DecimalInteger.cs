using System;
using System.Collections.Generic;
using slang.Lexing.Extensions;
using slang.Lexing.Tokens.Literals;
using slang.Lexing.Transitions.Constants;

namespace slang.Lexing.Transitions.Numbers
{
    static class DecimalInteger
    {
        public static readonly Dictionary<State,Func<LexerState,LexerState>> Transitions = new Dictionary<State,Func<LexerState,LexerState>> {
            {
                // digits ("l") ^
                State.S_number_with_integer_specifier,
                s => {
                    if(s.Value.IsUnsignedSpecifier ()) return s.TransitionTo (State.S_number_with_unsigned_integer_specifier, s.Buffer);
                    return s.Value.IsEnd () ? s.Returns(new IntegerLiteral (s.Buffer + Specifiers.LongSpecifier)) : s.ToError ();   
                }
            },
            {
                // digits ("u") ^
                State.S_number_with_unsigned_specifier,
                s => s.Value.IsLongSpecifier() ? s.TransitionTo (State.S_number_with_unsigned_integer_specifier, s.Buffer) : s.ToError () 
            },
            {
                // digits "u" "l" ^
                State.S_number_with_unsigned_integer_specifier,
                s => s.Value.IsEnd() ? s.Returns(new IntegerLiteral (s.Buffer + Specifiers.UnsignedSpecifier + Specifiers.LongSpecifier)) : s.ToError () 
            },
        };
    }
}

