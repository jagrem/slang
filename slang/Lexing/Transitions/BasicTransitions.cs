using System.Collections.Generic;
using System;
using slang.Lexing.Tokens.Keywords;
using slang.Lexing.Tokens;
using slang.Lexing.Tokens.Literals;
using slang.Lexing.Extensions;

namespace slang.Lexing
{
    static class BasicTransitions
    {
        public static readonly Dictionary<State,Func<LexerState,LexerState>> Transitions = new Dictionary<State,Func<LexerState,LexerState>> {
            { State.Zero, c => {switch(c.Value) {
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
                    case '9': return new LexerState { Token = Token.Empty, State = State.S_number, Buffer = new string(new char[] { c.Value }) };
                    case 'a': 
                    case 'b': return new LexerState { Token = Token.Empty, State = State.Identifier };
                    case 'c': return new LexerState { Token = Token.Empty, State = State.K_c_class };
                    case 'd': return new LexerState { Token = Token.Empty, State = State.K_d_def };
                    case 'e': return new LexerState { Token = Token.Empty, State = State.Identifier };
                    case 'f': return new LexerState { Token = Token.Empty, State = State.S_f_false };
                    case 'g': 
                    case 'h': return new LexerState { Token = Token.Empty, State = State.Identifier };
                    case 'i': return new LexerState { Token = Token.Empty, State = State.K_i_interface };
                    case 'j':
                    case 'k':
                    case 'l':
                    case 'm':
                    case 'n':
                    case 'o':
                    case 'p':
                    case 'q':
                    case 'r':
                    case 's': return new LexerState { Token = Token.Empty, State = State.Identifier };
                    case 't': return new LexerState { Token = Token.Empty, State = State.M_t_true_or_trait };
                    case 'u':
                    case 'v':
                    case 'w':
                    case 'x':
                    case 'y':
                    case 'z':
                    case 'A':
                    case 'B':
                    case 'C':
                    case 'D':
                    case 'E': return new LexerState { Token = Token.Empty, State = State.Identifier };
                    case 'F': return new LexerState { Token = Token.Empty, State = State.S_f_false };
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
                    case 'S': return new LexerState { Token = Token.Empty, State = State.Identifier };
                    case 'T': return new LexerState { Token = Token.Empty, State = State.S_t_true };
                    case 'U':
                    case 'V':
                    case 'W':
                    case 'X':
                    case 'Y':
                    case 'Z': return new LexerState { Token = Token.Empty, State = State.Identifier };
                    default: return new LexerState { Token = Token.Empty, State = State.Identifier };
                    }
                }
            },

            // class
            { State.K_c_class, c => c.Value == 'l' ? new LexerState { Token = Token.Empty, State = State.K_cl_class } : new LexerState { Token = Token.Empty, State = State.Identifier } },
            { State.K_cl_class, c => c.Value == 'a' ? new LexerState { Token = Token.Empty, State = State.K_cla_class } : new LexerState { Token = Token.Empty, State = State.Identifier } },
            { State.K_cla_class, c => c.Value == 's' ? new LexerState { Token = Token.Empty, State = State.K_clas_class } : new LexerState { Token = Token.Empty, State = State.Identifier } },
            { State.K_clas_class, c => c.Value == 's' ? new LexerState { Token = Token.Empty, State = State.K_class } : new LexerState { Token = Token.Empty, State = State.Identifier } },
            { State.K_class, c => c.Value == ' ' || c.Value == 0 ? new LexerState { Token = new ClassDefinition(), State = State.Zero } : new LexerState { Token = Token.Empty, State = State.Identifier } },

            // def
            { State.K_d_def, c => c.Value == 'e' ? new LexerState { Token = Token.Empty, State = State.K_de_def } : new LexerState { Token = Token.Empty, State = State.Identifier } },
            { State.K_de_def, c => c.Value == 'f' ? new LexerState { Token = Token.Empty, State = State.K_def } : new LexerState { Token = Token.Empty, State = State.Identifier } },
            { State.K_def, c => c.Value == ' ' || c.Value == 0 ? new LexerState { Token = new Definition(), State = State.Zero } : new LexerState { Token = Token.Empty, State = State.Identifier } },

            // false
            { State.S_f_false, c => c.Value == 'a' || c.Value == 'A' ? new LexerState { Token = Token.Empty, State = State.S_fa_false } : new LexerState { Token = Token.Empty, State = State.Identifier } },
            { State.S_fa_false, c => c.Value == 'l' || c.Value == 'L' ? new LexerState { Token = Token.Empty, State = State.S_fal_false } : new LexerState { Token = Token.Empty, State = State.Identifier } },
            { State.S_fal_false, c => c.Value == 's' || c.Value == 'S' ? new LexerState { Token = Token.Empty, State = State.S_fals_false } : new LexerState { Token = Token.Empty, State = State.Identifier } },
            { State.S_fals_false, c => c.Value == 'e' || c.Value == 'E' ? new LexerState { Token = Token.Empty, State = State.S_false } : new LexerState { Token = Token.Empty, State = State.Identifier } },
            { State.S_false, c => c.Value == ' ' || c.Value == 0 ? new LexerState { Token = new BooleanLiteral("false"), State = State.Zero } : new LexerState { Token = Token.Empty, State = State.Identifier } },


            // true or trait
            { State.M_t_true_or_trait, c => {
                    switch(c.Value) {
                    case 'r': return new LexerState { Token = Token.Empty, State = State.M_tr_true_or_trait };
                    case 'R': return new LexerState { Token = Token.Empty, State = State.S_tr_true };
                    default: return new LexerState { Token = Token.Empty, State = State.Identifier };
                    }
                }
            },
            { State.M_tr_true_or_trait, c => {
                    switch(c.Value) {
                    case 'U':
                    case 'u': return new LexerState { Token = Token.Empty, State = State.S_tru_true };
                    case 'a': return new LexerState { Token = Token.Empty, State = State.K_tra_trait };
                    default: return new LexerState { Token = Token.Empty, State = State.Identifier };
                    }
                }
            },

            // trait
            { State.K_tra_trait, c => c.Value == 'i' ? new LexerState { Token = Token.Empty, State = State.K_trai_trait } : new LexerState { Token = Token.Empty, State = State.Identifier } },
            { State.K_trai_trait, c => c.Value == 't' ? new LexerState { Token = Token.Empty, State = State.K_trait } : new LexerState { Token = Token.Empty, State = State.Identifier } },
            { State.K_trait, c => c.Value == ' ' ? new LexerState { Token = new TraitDefinition(), State = State.Zero } : new LexerState { Token = Token.Empty, State = State.Identifier } },

            // true
            { State.S_t_true, c => c.Value == 'r' || c.Value == 'R' ? new LexerState {  Token = Token.Empty, State = State.S_tr_true } : new LexerState { Token = Token.Empty, State = State.Identifier } },
            { State.S_tr_true, c => c.Value == 'u' || c.Value == 'U' ? new LexerState { Token = Token.Empty, State = State.S_tru_true } : new LexerState { Token = Token.Empty, State = State.Identifier } },
            { State.S_tru_true, c => c.Value == 'e' || c.Value == 'E' ? new LexerState { Token = Token.Empty, State = State.S_true } : new LexerState { Token = Token.Empty, State = State.Identifier } },
            { State.S_true, c => c.Value == ' ' || c.Value == 0 ? new LexerState { Token = new BooleanLiteral("true"), State = State.Zero } : new LexerState { Token = Token.Empty, State = State.Identifier } },
        };
    }
}

