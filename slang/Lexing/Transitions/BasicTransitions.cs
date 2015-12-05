using System.Collections.Generic;
using System;
using slang.Lexing.Tokens;
using slang.Lexing.Extensions;

namespace slang.Lexing.Transitions
{
    static class BasicTransitions
    {
        public static readonly Dictionary<State,Func<LexerState,LexerState>> Transitions = new Dictionary<State,Func<LexerState,LexerState>> {
            { 
                State.Zero,
                c => {
                    switch(c.Value) {
                    case (char)0: return new LexerState {  Token = new End(), State = State.Empty };
                    case ' ': return new LexerState { Token = Token.Empty, State = State.Zero };
                    case '.': return new LexerState { Token = Token.Empty, State = State.S_number_and_decimal_point, Buffer = "0." };
                    case '0': return c.TransitionTo(State.S_number_zero);
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9': return c.TransitionTo (State.S_number);
                    case 'a': return c.TransitionTo (State.M_a_abstract_or_as_or_async_or_await);
                    case 'b': return c.TransitionTo (State.Identifier);
                    case 'c': return c.TransitionTo (State.M_c_case_or_catch_or_char_or_checked_or_class_or_continue);
                    case 'd': return c.TransitionTo (State.M_d_decimal_or_def_or_default_or_dynamic_or_do_or_double);
                    case 'e': return c.TransitionTo (State.M_e_else_or_enum_or_extends);
                    case 'f': return c.TransitionTo (State.M_f_false_or_finally_or_fixed_or_float_or_for);
                    case 'g': 
                    case 'h': return c.TransitionTo (State.Identifier);
                    case 'i': return c.TransitionTo (State.M_i_if_or_implicit_or_import_or_in_or_int_or_internal_or_is);
                    case 'j':
                    case 'k': return c.TransitionTo (State.Identifier);
                    case 'l': return c.TransitionTo (State.M_l_lock_or_long);
                    case 'm': return c.TransitionTo (State.K_m_match);
                    case 'n': return c.TransitionTo (State.K_n_new);
                    case 'o': return c.TransitionTo (State.M_o_object_or_operator_or_override);
                    case 'p': return c.TransitionTo (State.M_p_package_or_private_or_protected);
                    case 'q': return c.TransitionTo (State.Identifier);
                    case 'r': return c.TransitionTo (State.M_r_readonly_or_return);
                    case 's': return c.TransitionTo (State.Identifier);
                    case 't': return c.TransitionTo (State.M_t_this_or_throw_or_trait_or_true_or_try_or_type);
                    case 'u': return c.TransitionTo (State.Identifier);
                    case 'v': return c.TransitionTo (State.M_v_val_or_var);
                    case 'w': return c.TransitionTo (State.M_w_while_or_with);
                    case 'x': return c.TransitionTo (State.Identifier);
                    case 'y': return c.TransitionTo (State.K_y_yield);
                    case 'z':
                    case 'A':
                    case 'B':
                    case 'C':
                    case 'D':
                    case 'E':
                    case 'F': 
                    case 'G':
                    case 'H':
                    case 'I':
                    case 'J':
                    case 'K':
                    case 'L':
                    case 'M':
                    case 'N':
                    case 'O':
                    case 'P':
                    case 'Q':
                    case 'R':
                    case 'S':
                    case 'T': 
                    case 'U':
                    case 'V':
                    case 'W':
                    case 'X':
                    case 'Y':
                    case 'Z': return new LexerState { Token = Token.Empty, State = State.Identifier };
                    case '&': return c.TransitionTo (State.P_ampersand);
                    case '\'': return c.TransitionTo (State.P_apostrophe);
                    case '*': return c.TransitionTo (State.P_asterisk);
                    case '@': return c.TransitionTo (State.P_at);
                    case '\\': return c.TransitionTo (State.P_back_slash);
                    case '^': return c.TransitionTo (State.P_caret);
                    case ':': return c.TransitionTo (State.P_colon);
                    case ',': return c.TransitionTo (State.P_comma);
                    case '$': return c.TransitionTo (State.P_dollar_sign);
                    //case '.': return c.TransitionTo (State.P_dot);
                    case '=': return c.TransitionTo (State.P_equals);
                    case '!': return c.TransitionTo (State.P_exclamation_mark);
                    case '/': return c.TransitionTo (State.P_forward_slash);
                    case '-': return c.TransitionTo (State.P_hyphen);
                    case '<': return c.TransitionTo (State.P_left_angle_bracket);
                    case '{': return c.TransitionTo (State.P_left_brace);
                    case '(': return c.TransitionTo (State.P_left_parenthesis);
                    case '[': return c.TransitionTo (State.P_left_square_bracket);
                    case '%': return c.TransitionTo (State.P_modulus);
                    case '#': return c.TransitionTo (State.P_octothorpe);
                    case '|': return c.TransitionTo (State.P_pipe);
                    case '+': return c.TransitionTo (State.P_plus);
                    case '?': return c.TransitionTo (State.P_question_mark);
                    case '>': return c.TransitionTo (State.P_right_angle_bracket);
                    case '}': return c.TransitionTo (State.P_right_brace);
                    case ')': return c.TransitionTo (State.P_right_parenthesis);
                    case ']': return c.TransitionTo (State.P_right_square_bracket);
                    case ';': return c.TransitionTo (State.P_semicolon);
                    case '~': return c.TransitionTo (State.P_tilde);
                    case '_': return c.TransitionTo (State.P_underscore);
                    default: return new LexerState { Token = Token.Empty, State = State.Identifier };
                    }
                }
            },
        };
    }
}

