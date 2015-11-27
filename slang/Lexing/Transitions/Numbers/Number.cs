using System;
using System.Collections.Generic;
using slang.Lexing.Extensions;
using slang.Lexing.Tokens.Literals;
using slang.Lexing.Transitions.Constants;

namespace slang.Lexing.Transitions.Numbers
{
    static class Number
    {
      public static readonly Dictionary<State,Func<LexerState,LexerState>> Transitions = new Dictionary<State,Func<LexerState,LexerState>> 
        { 
            {
                // "0" ^
                State.S_number_zero, 
                s => {
                    if(s.Value == 'x' || s.Value == 'X') return s.TransitionTo (State.S_number_and_hexadecimal_specifier, s.Buffer + Specifiers.HexadecimalSpecifier);
                    if(s.Value.IsEnd()) return s.Returns(new IntegerLiteral (s.Buffer));
                    if(s.Value.IsLongSpecifier ()) return s.TransitionTo (State.S_number_with_integer_specifier, s.Buffer);
                    if(s.Value.IsUnsignedSpecifier ()) return s.TransitionTo (State.S_number_with_unsigned_specifier, s.Buffer);
                    if(s.Value.IsDigit ()) return s.TransitionTo (State.S_number);
                    if(s.Value.IsExponent ()) return s.TransitionTo (State.S_number_with_exponent, s.Buffer + Specifiers.ExponentSpecifier);
                    if(s.Value.IsDoubleSpecifier ()) return s.TransitionTo (State.S_number_with_real_specifier, s.Buffer + Specifiers.DoubleSpecifier);
                    if(s.Value.IsFloatSpecifier ()) return s.TransitionTo (State.S_number_with_real_specifier, s.Buffer + Specifiers.FloatSpecifier);
                    if(s.Value.IsDecimalSpecifier ()) return s.TransitionTo (State.S_number_with_real_specifier, s.Buffer + Specifiers.DecimalSpecifier);
                    return s.Value.IsDot () ? s.TransitionTo (State.S_number_and_decimal_point) : s.ToError ();
                }
            },
            {
                // digits ^
                State.S_number, 
                s => {
                    if(s.Value.IsEnd()) return s.Returns(new IntegerLiteral (s.Buffer));
                    if(s.Value.IsLongSpecifier ()) return s.TransitionTo (State.S_number_with_integer_specifier, s.Buffer);
                    if(s.Value.IsUnsignedSpecifier ()) return s.TransitionTo (State.S_number_with_unsigned_specifier, s.Buffer);
                    if(s.Value.IsDigit ()) return s.TransitionTo (State.S_number);
                    if(s.Value.IsExponent ()) return s.TransitionTo (State.S_number_with_exponent, s.Buffer + Specifiers.ExponentSpecifier);
                    if(s.Value.IsDoubleSpecifier ()) return s.TransitionTo (State.S_number_with_real_specifier, s.Buffer + Specifiers.DoubleSpecifier);
                    if(s.Value.IsFloatSpecifier ()) return s.TransitionTo (State.S_number_with_real_specifier, s.Buffer + Specifiers.FloatSpecifier);
                    if(s.Value.IsDecimalSpecifier ()) return s.TransitionTo (State.S_number_with_real_specifier, s.Buffer + Specifiers.DecimalSpecifier);
                    return s.Value.IsDot () ? s.TransitionTo (State.S_number_and_decimal_point) : s.ToError ();
                }
            }
        };
    }
}

