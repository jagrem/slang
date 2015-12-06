using System;
using System.Collections.Generic;
using slang.Lexing.Extensions;
using slang.Lexing.Tokens;
 
namespace slang.Lexing.Transitions
{
    static class Punctuation
    {
        public static readonly Dictionary<State,Func<LexerState,LexerState>> Transitions = new Dictionary<State,Func<LexerState,LexerState>> 
        {
              { State.P_ampersand, s => s.Returns(new Symbol("&")) },
              { State.P_apostrophe, s => s.Returns(new Symbol("\'")) },
              { State.P_asterisk, s => s.Returns(new Symbol("*")) },
              { State.P_at, s => s.Returns(new Symbol("@")) },
              { State.P_back_slash, s => s.Returns(new Symbol("\\")) },
              { State.P_caret, s => s.Returns(new Symbol("^")) },
              { State.P_colon, s => s.Returns(new Symbol(":")) },
              { State.P_comma, s => s.Returns(new Symbol(",")) },
              { State.P_dollar_sign, s => s.Returns(new Symbol("$")) },
              { State.P_equals, s => s.Returns(new Symbol("=")) },
              { State.P_exclamation_mark, s => s.Returns(new Symbol("!")) },
              { State.P_forward_slash, s => s.Returns(new Symbol("/")) },
              { State.P_hyphen, s => s.Returns(new Symbol("-")) },
              { State.P_left_angle_bracket, s => s.Returns(new Symbol("<")) },
              { State.P_left_brace, s => s.Returns(new Symbol("{")) },
              { State.P_left_parenthesis, s => s.Returns(new Symbol("(")) },
              { State.P_left_square_bracket, s => s.Returns(new Symbol("[")) },
              { State.P_modulus, s => s.Returns(new Symbol("%")) },
              { State.P_octothorpe, s => s.Returns(new Symbol("#")) },
              { State.P_pipe, s => s.Returns(new Symbol("|")) },
              { State.P_plus, s => s.Returns(new Symbol("+")) },
              { State.P_question_mark, s => s.Returns(new Symbol("?")) },
              { State.P_right_angle_bracket, s => s.Returns(new Symbol(">")) },
              { State.P_right_brace, s => s.Returns(new Symbol("}")) },
              { State.P_right_parenthesis, s => s.Returns(new Symbol(")")) },
              { State.P_right_square_bracket, s => s.Returns(new Symbol("]")) },
              { State.P_semicolon, s => s.Returns(new Symbol(";")) },
              { State.P_tilde, s => s.Returns(new Symbol("~")) },
              { State.P_underscore, s => s.Returns(new Symbol("_")) },
        };
    }
}
