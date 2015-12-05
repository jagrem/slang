using System.Collections.Generic;
using System;
using slang.Lexing.Extensions;
using slang.Lexing.Tokens.Punctuation;

namespace slang.Lexing.Transitions
{
    static class Punctuation
    {
        public static readonly Dictionary<State,Func<LexerState,LexerState>> Transitions = new Dictionary<State,Func<LexerState,LexerState>> {
            {
                State.P_ampersand,
                s => s.Value.IsEnd() ? s.Returns (new Ampersand()) : s.ToError()
            },
            {
                State.P_apostrophe,
                s => s.Value.IsEnd() ? s.Returns (new Apostrophe()) : s.ToError()
            },
            {
                State.P_asterisk,
                s => s.Value.IsEnd() ? s.Returns (new Asterisk()) : s.ToError()
            },
            {
                State.P_at,
                s => s.Value.IsEnd() ? s.Returns (new At()) : s.ToError()
            },
            {
                State.P_back_slash,
                s => s.Value.IsEnd() ? s.Returns (new BackSlash()) : s.ToError()
            },
            {
                State.P_caret,
                s => s.Value.IsEnd() ? s.Returns (new Caret()) : s.ToError()
            },
            {
                State.P_colon,
                s => s.Value.IsEnd() ? s.Returns (new Colon()) : s.ToError()
            },
            {
                State.P_comma,
                s => s.Value.IsEnd() ? s.Returns (new Comma()) : s.ToError()
            },
            {
                State.P_dollar_sign,
                s => s.Value.IsEnd() ? s.Returns (new DollarSign()) : s.ToError()
            },
            {
                State.P_equals,
                s => s.Value.IsEnd() ? s.Returns (new Equals()) : s.ToError()
            },
            {
                State.P_exclamation_mark,
                s => s.Value.IsEnd() ? s.Returns (new ExclamationMark()) : s.ToError()
            },
            {
                State.P_forward_slash,
                s => s.Value.IsEnd() ? s.Returns (new ForwardSlash ()) : s.ToError()
            },
            {
                State.P_hyphen,
                s => s.Value.IsEnd() ? s.Returns (new Hyphen ()) : s.ToError()
            },
            {
                State.P_left_angle_bracket,
                s => s.Value.IsEnd() ? s.Returns (new LeftAngleBracket ()) : s.ToError()
            },
            {
                State.P_left_brace,
                s => s.Value.IsEnd() ? s.Returns (new LeftBrace ()) : s.ToError()
            },
            {
                State.P_left_parenthesis,
                s => s.Value.IsEnd() ? s.Returns (new LeftParenthesis ()) : s.ToError()
            },
            {
                State.P_left_square_bracket,
                s => s.Value.IsEnd() ? s.Returns (new LeftSquareBracket ()) : s.ToError()
            },
            {
                State.P_modulus,
                s => s.Value.IsEnd() ? s.Returns (new Modulus ()) : s.ToError()
            },
            {
                State.P_octothorpe,
                s => s.Value.IsEnd() ? s.Returns (new Octothorpe ()) : s.ToError()
            },
            {
                State.P_pipe,
                s => s.Value.IsEnd() ? s.Returns (new Pipe ()) : s.ToError()
            },
            {
                State.P_plus,
                s => s.Value.IsEnd() ? s.Returns (new Plus ()) : s.ToError()
            },
            {
                State.P_question_mark,
                s => s.Value.IsEnd() ? s.Returns (new QuestionMark ()) : s.ToError()
            },
            {
                State.P_right_angle_bracket,
                s => s.Value.IsEnd() ? s.Returns (new RightAngleBracket ()) : s.ToError()
            },
            {
                State.P_right_brace,
                s => s.Value.IsEnd() ? s.Returns (new RightBrace ()) : s.ToError()
            },
            {
                State.P_right_parenthesis,
                s => s.Value.IsEnd() ? s.Returns (new RightParenthesis ()) : s.ToError()
            },
            {
                State.P_right_square_bracket,
                s => s.Value.IsEnd() ? s.Returns (new RightSquareBracket ()) : s.ToError()
            },
            {
                State.P_semicolon,
                s => s.Value.IsEnd() ? s.Returns (new Semicolon ()) : s.ToError()
            },
            {
                State.P_tilde,
                s => s.Value.IsEnd() ? s.Returns (new Tilde ()) : s.ToError()
            },
            {
                State.P_underscore,
                s => s.Value.IsEnd() ? s.Returns (new Underscore ()) : s.ToError()
            }
        };
    }
}

