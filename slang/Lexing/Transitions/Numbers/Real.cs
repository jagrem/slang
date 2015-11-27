using System;
using System.Collections.Generic;
using slang.Lexing.Extensions;
using slang.Lexing.Tokens.Literals;
using slang.Lexing.Transitions.Constants;

namespace slang.Lexing.Transitions.Numbers
{
    static class Real
    {
        public static readonly Dictionary<State,Func<LexerState,LexerState>> Transitions = new Dictionary<State,Func<LexerState,LexerState>> {
            {
                // digits "." ^
                State.S_number_and_decimal_point,
                s => s.Value.IsDigit () ? s.TransitionTo (State.S_decimal_point_and_number) : s.ToError ()
            }, 
            {
                // digit "." digit ^ 
                State.S_decimal_point_and_number,
                s => {
                    if(s.Value.IsEnd()) return s.Returns (new RealLiteral (s.Buffer + Specifiers.DoubleSpecifier));
                    if(s.Value.IsDigit ()) return s.TransitionTo (State.S_decimal_point_and_number);
                    if(s.Value.IsExponent ()) return s.TransitionTo (State.S_number_with_exponent, s.Buffer + Specifiers.ExponentSpecifier);
                    if(s.Value.IsDoubleSpecifier ()) return s.TransitionTo (State.S_number_with_real_specifier, s.Buffer + Specifiers.DoubleSpecifier);
                    if(s.Value.IsFloatSpecifier ()) return s.TransitionTo (State.S_number_with_real_specifier, s.Buffer + Specifiers.FloatSpecifier);
                    return s.Value.IsDecimalSpecifier () ? s.TransitionTo (State.S_number_with_real_specifier, s.Buffer + Specifiers.DecimalSpecifier) : s.ToError ();
                }
            }, 
            {
                // digits ("d" | "f" | "m") ^
                State.S_number_with_real_specifier,
                s => s.Value.IsEnd () ? s.Returns(new RealLiteral (s.Buffer)) : s.ToError () 
            },

            {
                // digits "e" ^
                State.S_number_with_exponent,
                s => {
                    if(s.Value.IsDigit ()) return s.TransitionTo (State.S_signed_exponent_and_number, s.Buffer + "+" + s.Value);
                    return s.Value.IsSign () ? s.TransitionTo (State.S_number_with_signed_exponent) : s.ToError ();
                }
            },
            {
                // digits "e" ("+"|"-") ^
                State.S_number_with_signed_exponent,
                s => s.Value.IsDigit () ? s.TransitionTo (State.S_signed_exponent_and_number, s.Buffer + s.Value) : s.ToError ()
            }, 
            {
                // digits "e" ("+"|"-") digit ^
                State.S_signed_exponent_and_number,
                s => {
                    if(s.Value.IsEnd ()) return s.Returns (new RealLiteral (s.Buffer + "d"));
                    if(s.Value.IsDigit ()) return s.TransitionTo (State.S_signed_exponent_and_number);
                    if(s.Value.IsExponent ()) return s.TransitionTo (State.S_signed_exponent_and_number_with_specifier, s.Buffer + Specifiers.ExponentSpecifier);
                    if(s.Value.IsDoubleSpecifier ()) return s.TransitionTo (State.S_signed_exponent_and_number_with_specifier, s.Buffer + Specifiers.DoubleSpecifier);
                    if(s.Value.IsFloatSpecifier ()) return s.TransitionTo (State.S_signed_exponent_and_number_with_specifier, s.Buffer + Specifiers.FloatSpecifier);
                    if(s.Value.IsDecimalSpecifier ()) return s.TransitionTo (State.S_signed_exponent_and_number_with_specifier, s.Buffer + Specifiers.DecimalSpecifier);
                    return  s.ToError ();
                }
            },
            {
                // digits "e" ("+"|"-") digit ("d" | "f" | "m") ^
                State.S_signed_exponent_and_number_with_specifier,
                s => s.Value.IsEnd () ? s.Returns(new RealLiteral (s.Buffer)) : s.ToError () 
            },
        };
    }
}

