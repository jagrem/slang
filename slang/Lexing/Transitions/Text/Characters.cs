using System.Collections.Generic;
using System;
using slang.Lexing.Extensions;
using slang.Lexing.Tokens.Literals;

namespace slang.Lexing.Transitions.Text
{
    public static class Characters
    {
        public static readonly Dictionary<State,Func<LexerState,LexerState>> Transitions = new Dictionary<State,Func<LexerState,LexerState>> {
            {
                State.C_single_opening_quote,
                s => { 
                    switch(s.Value) {
                    case '\'': return s.TransitionTo (State.C_single_closing_quote);
                    case '\\': return s.TransitionTo (State.C_escape);
                    case (char)0: return s.ToError ();
                    default: return s.TransitionTo (State.C_single_opening_quote);
                    }
                }
            },
            {
                State.C_escape,
                s => {
                    switch(s.Value) {
                    case '\'':
                    case '"':
                    case '0':
                    case 'a':
                    case 'b':
                    case 'f':
                    case 'n':
                    case 'r':
                    case 't':
                    case 'v':
                    case '\\': return s.TransitionTo (State.C_single_opening_quote);
                    case 'x': return s.TransitionTo (State.C_escape_hexadecimal_character);
                    case 'u': return s.TransitionTo (State.C_escape_unicode_character_short);
                    case 'U': return s.TransitionTo (State.C_escape_unicode_character_long);
                    default: return s.ToError ();
                    }
                }
            },
            {
                State.C_escape_hexadecimal_character,
                s => s.Value.IsHexadecimalDigit () ? s.TransitionTo (State.C_hexadecimal_character_1) : s.ToError ()
            },
            {
                State.C_hexadecimal_character_1,
                s => {
                    if(s.Value.IsHexadecimalDigit ()) { return s.TransitionTo (State.C_hexadecimal_character_2); }
                    if(s.Value == '\'') { return s.TransitionTo (State.C_single_closing_quote); }
                    return s.ToError ();
                }
            },
            {
                State.C_hexadecimal_character_2,
                s => {
                    if(s.Value.IsHexadecimalDigit ()) { return s.TransitionTo (State.C_hexadecimal_character_3); }
                    if(s.Value == '\'') { return s.TransitionTo (State.C_single_closing_quote); }
                    return s.ToError ();
                }
            },
            {
                State.C_hexadecimal_character_3,
                s => {
                    if(s.Value.IsHexadecimalDigit ()) { return s.TransitionTo (State.C_hexadecimal_character_4); }
                    if(s.Value == '\'') { return s.TransitionTo (State.C_single_closing_quote); }
                    return s.ToError ();
                }
            },
            {
                State.C_hexadecimal_character_4,
                s => {
                    if(s.Value == '\'') { return s.TransitionTo (State.C_single_closing_quote); }
                    return s.ToError ();
                }
            },
            {
                State.C_escape_unicode_character_short,
                s => {
                    if(s.Value.IsHexadecimalDigit ()) { return s.TransitionTo (State.C_unicode_character_short_1); }
                    return s.ToError ();
                }
            },
            {
                State.C_unicode_character_short_1,
                s => {
                    if(s.Value.IsHexadecimalDigit ()) { return s.TransitionTo (State.C_unicode_character_short_2); }
                    return s.ToError ();
                }
            },
            {
                State.C_unicode_character_short_2,
                s => {
                    if(s.Value.IsHexadecimalDigit ()) { return s.TransitionTo (State.C_unicode_character_short_3); }
                    return s.ToError ();
                }
            },
            {
                State.C_unicode_character_short_3,
                s => {
                    if(s.Value.IsHexadecimalDigit ()) { return s.TransitionTo (State.C_unicode_character_short_4); }
                    return s.ToError ();
                }
            },
            {
                State.C_unicode_character_short_4,
                s => {
                    if(s.Value == '\'') { return s.TransitionTo (State.C_single_closing_quote); }
                    return s.ToError ();
                }
            },
            {
                State.C_escape_unicode_character_long,
                s => {
                    if(s.Value.IsHexadecimalDigit ()) { return s.TransitionTo (State.C_unicode_character_long_1); }
                    return s.ToError ();
                }
            },
            {
                State.C_unicode_character_long_1,
                s => {
                    if(s.Value.IsHexadecimalDigit ()) { return s.TransitionTo (State.C_unicode_character_long_2); }
                    return s.ToError ();
                }
            },
            {
                State.C_unicode_character_long_2,
                s => {
                    if(s.Value.IsHexadecimalDigit ()) { return s.TransitionTo (State.C_unicode_character_long_3); }
                    return s.ToError ();
                }
            },
            {
                State.C_unicode_character_long_3,
                s => {
                    if(s.Value.IsHexadecimalDigit ()) { return s.TransitionTo (State.C_unicode_character_long_4); }
                    return s.ToError ();
                }
            },
            {
                State.C_unicode_character_long_4,
                s => {
                    if(s.Value.IsHexadecimalDigit ()) { return s.TransitionTo (State.C_unicode_character_long_5); }
                    return s.ToError ();
                }
            },
            {
                State.C_unicode_character_long_5,
                s => {
                    if(s.Value.IsHexadecimalDigit ()) { return s.TransitionTo (State.C_unicode_character_long_6); }
                    return s.ToError ();
                }
            },
            {
                State.C_unicode_character_long_6,
                s => {
                    if(s.Value.IsHexadecimalDigit ()) { return s.TransitionTo (State.C_unicode_character_long_7); }
                    return s.ToError ();
                }
            },
            {
                State.C_unicode_character_long_7,
                s => {
                    if(s.Value.IsHexadecimalDigit ()) { return s.TransitionTo (State.C_unicode_character_long_8); }
                    return s.ToError ();
                }
            },
            {
                State.C_unicode_character_long_8,
                s => {
                    if(s.Value == '\'') { return s.TransitionTo (State.C_single_closing_quote); }
                    return s.ToError ();
                }
            },
            {
                State.C_single_closing_quote,
                s => s.Value.IsEnd() ? s.Returns (new CharacterLiteral(s.Buffer)) : s.ToError ()
            }
        };
    }
}

