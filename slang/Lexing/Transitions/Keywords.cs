using System.Collections.Generic;
using System;
using slang.Lexing.Extensions;
using slang.Lexing.Tokens.Keywords;
using slang.Lexing.Tokens;

namespace slang.Lexing.Transitions
{
    static class Keywords
    {
        public static readonly Dictionary<State,Func<LexerState,LexerState>> Transitions = new Dictionary<State,Func<LexerState,LexerState>> 
        {
            { 
                State.M_a_abstract_or_as_or_async_or_await,
                s =>  { 
                    switch(s.Value) {
                    case 'b': return s.TransitionTo(State.K_ab_abstract);
                    case 's': return s.TransitionTo(State.M_as_as_or_async);
                    case 'w': return s.TransitionTo(State.K_aw_await);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_ab_abstract,
                s =>  { 
                    switch(s.Value) {
                    case 's': return s.TransitionTo(State.K_abs_abstract);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_abs_abstract,
                s =>  { 
                    switch(s.Value) {
                    case 't': return s.TransitionTo(State.K_abst_abstract);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_abst_abstract,
                s =>  { 
                    switch(s.Value) {
                    case 'r': return s.TransitionTo(State.K_abstr_abstract);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_abstr_abstract,
                s =>  { 
                    switch(s.Value) {
                    case 'a': return s.TransitionTo(State.K_abstra_abstract);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_abstra_abstract,
                s =>  { 
                    switch(s.Value) {
                    case 'c': return s.TransitionTo(State.K_abstrac_abstract);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_abstrac_abstract,
                s =>  { 
                    switch(s.Value) {
                    case 't': return s.TransitionTo(State.K_abstract);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_abstract,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("abstract"));
                    case (char)0: return s.Returns(new Keyword("abstract"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.M_as_as_or_async,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("as"));
                    case (char)0: return s.Returns(new Keyword("as"));
                    case 'y': return s.TransitionTo(State.K_asy_async);
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_asy_async,
                s =>  { 
                    switch(s.Value) {
                    case 'n': return s.TransitionTo(State.K_asyn_async);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_asyn_async,
                s =>  { 
                    switch(s.Value) {
                    case 'c': return s.TransitionTo(State.K_async);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_async,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("async"));
                    case (char)0: return s.Returns(new Keyword("async"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_aw_await,
                s =>  { 
                    switch(s.Value) {
                    case 'a': return s.TransitionTo(State.K_awa_await);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_awa_await,
                s =>  { 
                    switch(s.Value) {
                    case 'i': return s.TransitionTo(State.K_awai_await);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_awai_await,
                s =>  { 
                    switch(s.Value) {
                    case 't': return s.TransitionTo(State.K_await);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_await,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("await"));
                    case (char)0: return s.Returns(new Keyword("await"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.M_b_base_or_bool_or_break_or_byte,
                s =>  { 
                    switch(s.Value) {
                    case 'a': return s.TransitionTo(State.K_ba_base);
                    case 'o': return s.TransitionTo(State.K_bo_bool);
                    case 'r': return s.TransitionTo(State.K_br_break);
                    case 'y': return s.TransitionTo(State.K_by_byte);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_ba_base,
                s =>  { 
                    switch(s.Value) {
                    case 's': return s.TransitionTo(State.K_bas_base);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_bas_base,
                s =>  { 
                    switch(s.Value) {
                    case 'e': return s.TransitionTo(State.K_base);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_base,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("base"));
                    case (char)0: return s.Returns(new Keyword("base"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_bo_bool,
                s =>  { 
                    switch(s.Value) {
                    case 'o': return s.TransitionTo(State.K_boo_bool);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_boo_bool,
                s =>  { 
                    switch(s.Value) {
                    case 'l': return s.TransitionTo(State.K_bool);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_bool,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("bool"));
                    case (char)0: return s.Returns(new Keyword("bool"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_br_break,
                s =>  { 
                    switch(s.Value) {
                    case 'e': return s.TransitionTo(State.K_bre_break);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_bre_break,
                s =>  { 
                    switch(s.Value) {
                    case 'a': return s.TransitionTo(State.K_brea_break);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_brea_break,
                s =>  { 
                    switch(s.Value) {
                    case 'k': return s.TransitionTo(State.K_break);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_break,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("break"));
                    case (char)0: return s.Returns(new Keyword("break"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_by_byte,
                s =>  { 
                    switch(s.Value) {
                    case 't': return s.TransitionTo(State.K_byt_byte);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_byt_byte,
                s =>  { 
                    switch(s.Value) {
                    case 'e': return s.TransitionTo(State.K_byte);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_byte,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("byte"));
                    case (char)0: return s.Returns(new Keyword("byte"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.M_c_case_or_catch_or_char_or_checked_or_class_or_continue,
                s =>  { 
                    switch(s.Value) {
                    case 'a': return s.TransitionTo(State.M_ca_case_or_catch);
                    case 'h': return s.TransitionTo(State.M_ch_char_or_checked);
                    case 'l': return s.TransitionTo(State.K_cl_class);
                    case 'o': return s.TransitionTo(State.K_co_continue);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.M_ca_case_or_catch,
                s =>  { 
                    switch(s.Value) {
                    case 's': return s.TransitionTo(State.K_cas_case);
                    case 't': return s.TransitionTo(State.K_cat_catch);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_cas_case,
                s =>  { 
                    switch(s.Value) {
                    case 'e': return s.TransitionTo(State.K_case);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_case,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("case"));
                    case (char)0: return s.Returns(new Keyword("case"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_cat_catch,
                s =>  { 
                    switch(s.Value) {
                    case 'c': return s.TransitionTo(State.K_catc_catch);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_catc_catch,
                s =>  { 
                    switch(s.Value) {
                    case 'h': return s.TransitionTo(State.K_catch);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_catch,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("catch"));
                    case (char)0: return s.Returns(new Keyword("catch"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.M_ch_char_or_checked,
                s =>  { 
                    switch(s.Value) {
                    case 'a': return s.TransitionTo(State.K_cha_char);
                    case 'e': return s.TransitionTo(State.K_che_checked);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_cha_char,
                s =>  { 
                    switch(s.Value) {
                    case 'r': return s.TransitionTo(State.K_char);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_char,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("char"));
                    case (char)0: return s.Returns(new Keyword("char"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_che_checked,
                s =>  { 
                    switch(s.Value) {
                    case 'c': return s.TransitionTo(State.K_chec_checked);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_chec_checked,
                s =>  { 
                    switch(s.Value) {
                    case 'k': return s.TransitionTo(State.K_check_checked);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_check_checked,
                s =>  { 
                    switch(s.Value) {
                    case 'e': return s.TransitionTo(State.K_checke_checked);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_checke_checked,
                s =>  { 
                    switch(s.Value) {
                    case 'd': return s.TransitionTo(State.K_checked);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_checked,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("checked"));
                    case (char)0: return s.Returns(new Keyword("checked"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_cl_class,
                s =>  { 
                    switch(s.Value) {
                    case 'a': return s.TransitionTo(State.K_cla_class);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_cla_class,
                s =>  { 
                    switch(s.Value) {
                    case 's': return s.TransitionTo(State.K_clas_class);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_clas_class,
                s =>  { 
                    switch(s.Value) {
                    case 's': return s.TransitionTo(State.K_class);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_class,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("class"));
                    case (char)0: return s.Returns(new Keyword("class"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_co_continue,
                s =>  { 
                    switch(s.Value) {
                    case 'n': return s.TransitionTo(State.K_con_continue);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_con_continue,
                s =>  { 
                    switch(s.Value) {
                    case 't': return s.TransitionTo(State.K_cont_continue);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_cont_continue,
                s =>  { 
                    switch(s.Value) {
                    case 'i': return s.TransitionTo(State.K_conti_continue);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_conti_continue,
                s =>  { 
                    switch(s.Value) {
                    case 'n': return s.TransitionTo(State.K_contin_continue);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_contin_continue,
                s =>  { 
                    switch(s.Value) {
                    case 'u': return s.TransitionTo(State.K_continu_continue);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_continu_continue,
                s =>  { 
                    switch(s.Value) {
                    case 'e': return s.TransitionTo(State.K_continue);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_continue,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("continue"));
                    case (char)0: return s.Returns(new Keyword("continue"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.M_d_decimal_or_def_or_default_or_dynamic_or_do_or_double,
                s =>  { 
                    switch(s.Value) {
                    case 'e': return s.TransitionTo(State.M_de_decimal_or_def_or_default);
                    case 'y': return s.TransitionTo(State.K_dy_dynamic);
                    case 'o': return s.TransitionTo(State.M_do_do_or_double);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.M_de_decimal_or_def_or_default,
                s =>  { 
                    switch(s.Value) {
                    case 'c': return s.TransitionTo(State.K_dec_decimal);
                    case 'f': return s.TransitionTo(State.M_def_def_or_default);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_dec_decimal,
                s =>  { 
                    switch(s.Value) {
                    case 'i': return s.TransitionTo(State.K_deci_decimal);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_deci_decimal,
                s =>  { 
                    switch(s.Value) {
                    case 'm': return s.TransitionTo(State.K_decim_decimal);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_decim_decimal,
                s =>  { 
                    switch(s.Value) {
                    case 'a': return s.TransitionTo(State.K_decima_decimal);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_decima_decimal,
                s =>  { 
                    switch(s.Value) {
                    case 'l': return s.TransitionTo(State.K_decimal);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_decimal,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("decimal"));
                    case (char)0: return s.Returns(new Keyword("decimal"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.M_def_def_or_default,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("def"));
                    case (char)0: return s.Returns(new Keyword("def"));
                    case 'a': return s.TransitionTo(State.K_defa_default);
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_defa_default,
                s =>  { 
                    switch(s.Value) {
                    case 'u': return s.TransitionTo(State.K_defau_default);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_defau_default,
                s =>  { 
                    switch(s.Value) {
                    case 'l': return s.TransitionTo(State.K_defaul_default);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_defaul_default,
                s =>  { 
                    switch(s.Value) {
                    case 't': return s.TransitionTo(State.K_default);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_default,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("default"));
                    case (char)0: return s.Returns(new Keyword("default"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_dy_dynamic,
                s =>  { 
                    switch(s.Value) {
                    case 'n': return s.TransitionTo(State.K_dyn_dynamic);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_dyn_dynamic,
                s =>  { 
                    switch(s.Value) {
                    case 'a': return s.TransitionTo(State.K_dyna_dynamic);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_dyna_dynamic,
                s =>  { 
                    switch(s.Value) {
                    case 'm': return s.TransitionTo(State.K_dynam_dynamic);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_dynam_dynamic,
                s =>  { 
                    switch(s.Value) {
                    case 'i': return s.TransitionTo(State.K_dynami_dynamic);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_dynami_dynamic,
                s =>  { 
                    switch(s.Value) {
                    case 'c': return s.TransitionTo(State.K_dynamic);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_dynamic,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("dynamic"));
                    case (char)0: return s.Returns(new Keyword("dynamic"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.M_do_do_or_double,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("do"));
                    case (char)0: return s.Returns(new Keyword("do"));
                    case 'u': return s.TransitionTo(State.K_dou_double);
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_dou_double,
                s =>  { 
                    switch(s.Value) {
                    case 'b': return s.TransitionTo(State.K_doub_double);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_doub_double,
                s =>  { 
                    switch(s.Value) {
                    case 'l': return s.TransitionTo(State.K_doubl_double);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_doubl_double,
                s =>  { 
                    switch(s.Value) {
                    case 'e': return s.TransitionTo(State.K_double);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_double,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("double"));
                    case (char)0: return s.Returns(new Keyword("double"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.M_e_else_or_enum_or_extends,
                s =>  { 
                    switch(s.Value) {
                    case 'l': return s.TransitionTo(State.K_el_else);
                    case 'n': return s.TransitionTo(State.K_en_enum);
                    case 'x': return s.TransitionTo(State.K_ex_extends);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_el_else,
                s =>  { 
                    switch(s.Value) {
                    case 's': return s.TransitionTo(State.K_els_else);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_els_else,
                s =>  { 
                    switch(s.Value) {
                    case 'e': return s.TransitionTo(State.K_else);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_else,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("else"));
                    case (char)0: return s.Returns(new Keyword("else"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_en_enum,
                s =>  { 
                    switch(s.Value) {
                    case 'u': return s.TransitionTo(State.K_enu_enum);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_enu_enum,
                s =>  { 
                    switch(s.Value) {
                    case 'm': return s.TransitionTo(State.K_enum);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_enum,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("enum"));
                    case (char)0: return s.Returns(new Keyword("enum"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_ex_extends,
                s =>  { 
                    switch(s.Value) {
                    case 't': return s.TransitionTo(State.K_ext_extends);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_ext_extends,
                s =>  { 
                    switch(s.Value) {
                    case 'e': return s.TransitionTo(State.K_exte_extends);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_exte_extends,
                s =>  { 
                    switch(s.Value) {
                    case 'n': return s.TransitionTo(State.K_exten_extends);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_exten_extends,
                s =>  { 
                    switch(s.Value) {
                    case 'd': return s.TransitionTo(State.K_extend_extends);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_extend_extends,
                s =>  { 
                    switch(s.Value) {
                    case 's': return s.TransitionTo(State.K_extends);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_extends,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("extends"));
                    case (char)0: return s.Returns(new Keyword("extends"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.M_f_false_or_finally_or_fixed_or_float_or_for,
                s =>  { 
                    switch(s.Value) {
                    case 'a': return s.TransitionTo(State.K_fa_false);
                    case 'i': return s.TransitionTo(State.M_fi_finally_or_fixed);
                    case 'l': return s.TransitionTo(State.K_fl_float);
                    case 'o': return s.TransitionTo(State.K_fo_for);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_fa_false,
                s =>  { 
                    switch(s.Value) {
                    case 'l': return s.TransitionTo(State.K_fal_false);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_fal_false,
                s =>  { 
                    switch(s.Value) {
                    case 's': return s.TransitionTo(State.K_fals_false);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_fals_false,
                s =>  { 
                    switch(s.Value) {
                    case 'e': return s.TransitionTo(State.K_false);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_false,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("false"));
                    case (char)0: return s.Returns(new Keyword("false"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.M_fi_finally_or_fixed,
                s =>  { 
                    switch(s.Value) {
                    case 'n': return s.TransitionTo(State.K_fin_finally);
                    case 'x': return s.TransitionTo(State.K_fix_fixed);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_fin_finally,
                s =>  { 
                    switch(s.Value) {
                    case 'a': return s.TransitionTo(State.K_fina_finally);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_fina_finally,
                s =>  { 
                    switch(s.Value) {
                    case 'l': return s.TransitionTo(State.K_final_finally);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_final_finally,
                s =>  { 
                    switch(s.Value) {
                    case 'l': return s.TransitionTo(State.K_finall_finally);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_finall_finally,
                s =>  { 
                    switch(s.Value) {
                    case 'y': return s.TransitionTo(State.K_finally);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_finally,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("finally"));
                    case (char)0: return s.Returns(new Keyword("finally"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_fix_fixed,
                s =>  { 
                    switch(s.Value) {
                    case 'e': return s.TransitionTo(State.K_fixe_fixed);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_fixe_fixed,
                s =>  { 
                    switch(s.Value) {
                    case 'd': return s.TransitionTo(State.K_fixed);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_fixed,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("fixed"));
                    case (char)0: return s.Returns(new Keyword("fixed"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_fl_float,
                s =>  { 
                    switch(s.Value) {
                    case 'o': return s.TransitionTo(State.K_flo_float);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_flo_float,
                s =>  { 
                    switch(s.Value) {
                    case 'a': return s.TransitionTo(State.K_floa_float);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_floa_float,
                s =>  { 
                    switch(s.Value) {
                    case 't': return s.TransitionTo(State.K_float);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_float,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("float"));
                    case (char)0: return s.Returns(new Keyword("float"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_fo_for,
                s =>  { 
                    switch(s.Value) {
                    case 'r': return s.TransitionTo(State.K_for);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_for,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("for"));
                    case (char)0: return s.Returns(new Keyword("for"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.M_i_if_or_implicit_or_import_or_in_or_int_or_internal_or_is,
                s =>  { 
                    switch(s.Value) {
                    case 'f': return s.TransitionTo(State.K_if);
                    case 'm': return s.TransitionTo(State.M_im_implicit_or_import);
                    case 'n': return s.TransitionTo(State.M_in_in_or_int_or_internal);
                    case 's': return s.TransitionTo(State.K_is);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_if,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("if"));
                    case (char)0: return s.Returns(new Keyword("if"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.M_im_implicit_or_import,
                s =>  { 
                    switch(s.Value) {
                    case 'p': return s.TransitionTo(State.M_imp_implicit_or_import);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.M_imp_implicit_or_import,
                s =>  { 
                    switch(s.Value) {
                    case 'l': return s.TransitionTo(State.K_impl_implicit);
                    case 'o': return s.TransitionTo(State.K_impo_import);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_impl_implicit,
                s =>  { 
                    switch(s.Value) {
                    case 'i': return s.TransitionTo(State.K_impli_implicit);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_impli_implicit,
                s =>  { 
                    switch(s.Value) {
                    case 'c': return s.TransitionTo(State.K_implic_implicit);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_implic_implicit,
                s =>  { 
                    switch(s.Value) {
                    case 'i': return s.TransitionTo(State.K_implici_implicit);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_implici_implicit,
                s =>  { 
                    switch(s.Value) {
                    case 't': return s.TransitionTo(State.K_implicit);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_implicit,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("implicit"));
                    case (char)0: return s.Returns(new Keyword("implicit"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_impo_import,
                s =>  { 
                    switch(s.Value) {
                    case 'r': return s.TransitionTo(State.K_impor_import);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_impor_import,
                s =>  { 
                    switch(s.Value) {
                    case 't': return s.TransitionTo(State.K_import);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_import,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("import"));
                    case (char)0: return s.Returns(new Keyword("import"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.M_in_in_or_int_or_internal,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("in"));
                    case (char)0: return s.Returns(new Keyword("in"));
                    case 't': return s.TransitionTo(State.M_int_int_or_internal);
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.M_int_int_or_internal,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("int"));
                    case (char)0: return s.Returns(new Keyword("int"));
                    case 'e': return s.TransitionTo(State.K_inte_internal);
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_inte_internal,
                s =>  { 
                    switch(s.Value) {
                    case 'r': return s.TransitionTo(State.K_inter_internal);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_inter_internal,
                s =>  { 
                    switch(s.Value) {
                    case 'n': return s.TransitionTo(State.K_intern_internal);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_intern_internal,
                s =>  { 
                    switch(s.Value) {
                    case 'a': return s.TransitionTo(State.K_interna_internal);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_interna_internal,
                s =>  { 
                    switch(s.Value) {
                    case 'l': return s.TransitionTo(State.K_internal);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_internal,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("internal"));
                    case (char)0: return s.Returns(new Keyword("internal"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_is,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("is"));
                    case (char)0: return s.Returns(new Keyword("is"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.M_l_lock_or_long,
                s =>  { 
                    switch(s.Value) {
                    case 'o': return s.TransitionTo(State.M_lo_lock_or_long);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.M_lo_lock_or_long,
                s =>  { 
                    switch(s.Value) {
                    case 'c': return s.TransitionTo(State.K_loc_lock);
                    case 'n': return s.TransitionTo(State.K_lon_long);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_loc_lock,
                s =>  { 
                    switch(s.Value) {
                    case 'k': return s.TransitionTo(State.K_lock);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_lock,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("lock"));
                    case (char)0: return s.Returns(new Keyword("lock"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_lon_long,
                s =>  { 
                    switch(s.Value) {
                    case 'g': return s.TransitionTo(State.K_long);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_long,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("long"));
                    case (char)0: return s.Returns(new Keyword("long"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_m_match,
                s =>  { 
                    switch(s.Value) {
                    case 'a': return s.TransitionTo(State.K_ma_match);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_ma_match,
                s =>  { 
                    switch(s.Value) {
                    case 't': return s.TransitionTo(State.K_mat_match);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_mat_match,
                s =>  { 
                    switch(s.Value) {
                    case 'c': return s.TransitionTo(State.K_matc_match);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_matc_match,
                s =>  { 
                    switch(s.Value) {
                    case 'h': return s.TransitionTo(State.K_match);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_match,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("match"));
                    case (char)0: return s.Returns(new Keyword("match"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_n_new,
                s =>  { 
                    switch(s.Value) {
                    case 'e': return s.TransitionTo(State.K_ne_new);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_ne_new,
                s =>  { 
                    switch(s.Value) {
                    case 'w': return s.TransitionTo(State.K_new);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_new,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("new"));
                    case (char)0: return s.Returns(new Keyword("new"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.M_o_object_or_operator_or_override,
                s =>  { 
                    switch(s.Value) {
                    case 'b': return s.TransitionTo(State.K_ob_object);
                    case 'p': return s.TransitionTo(State.K_op_operator);
                    case 'v': return s.TransitionTo(State.K_ov_override);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_ob_object,
                s =>  { 
                    switch(s.Value) {
                    case 'j': return s.TransitionTo(State.K_obj_object);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_obj_object,
                s =>  { 
                    switch(s.Value) {
                    case 'e': return s.TransitionTo(State.K_obje_object);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_obje_object,
                s =>  { 
                    switch(s.Value) {
                    case 'c': return s.TransitionTo(State.K_objec_object);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_objec_object,
                s =>  { 
                    switch(s.Value) {
                    case 't': return s.TransitionTo(State.K_object);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_object,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("object"));
                    case (char)0: return s.Returns(new Keyword("object"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_op_operator,
                s =>  { 
                    switch(s.Value) {
                    case 'e': return s.TransitionTo(State.K_ope_operator);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_ope_operator,
                s =>  { 
                    switch(s.Value) {
                    case 'r': return s.TransitionTo(State.K_oper_operator);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_oper_operator,
                s =>  { 
                    switch(s.Value) {
                    case 'a': return s.TransitionTo(State.K_opera_operator);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_opera_operator,
                s =>  { 
                    switch(s.Value) {
                    case 't': return s.TransitionTo(State.K_operat_operator);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_operat_operator,
                s =>  { 
                    switch(s.Value) {
                    case 'o': return s.TransitionTo(State.K_operato_operator);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_operato_operator,
                s =>  { 
                    switch(s.Value) {
                    case 'r': return s.TransitionTo(State.K_operator);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_operator,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("operator"));
                    case (char)0: return s.Returns(new Keyword("operator"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_ov_override,
                s =>  { 
                    switch(s.Value) {
                    case 'e': return s.TransitionTo(State.K_ove_override);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_ove_override,
                s =>  { 
                    switch(s.Value) {
                    case 'r': return s.TransitionTo(State.K_over_override);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_over_override,
                s =>  { 
                    switch(s.Value) {
                    case 'r': return s.TransitionTo(State.K_overr_override);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_overr_override,
                s =>  { 
                    switch(s.Value) {
                    case 'i': return s.TransitionTo(State.K_overri_override);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_overri_override,
                s =>  { 
                    switch(s.Value) {
                    case 'd': return s.TransitionTo(State.K_overrid_override);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_overrid_override,
                s =>  { 
                    switch(s.Value) {
                    case 'e': return s.TransitionTo(State.K_override);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_override,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("override"));
                    case (char)0: return s.Returns(new Keyword("override"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.M_p_package_or_private_or_protected,
                s =>  { 
                    switch(s.Value) {
                    case 'a': return s.TransitionTo(State.K_pa_package);
                    case 'r': return s.TransitionTo(State.M_pr_private_or_protected);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_pa_package,
                s =>  { 
                    switch(s.Value) {
                    case 'c': return s.TransitionTo(State.K_pac_package);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_pac_package,
                s =>  { 
                    switch(s.Value) {
                    case 'k': return s.TransitionTo(State.K_pack_package);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_pack_package,
                s =>  { 
                    switch(s.Value) {
                    case 'a': return s.TransitionTo(State.K_packa_package);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_packa_package,
                s =>  { 
                    switch(s.Value) {
                    case 'g': return s.TransitionTo(State.K_packag_package);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_packag_package,
                s =>  { 
                    switch(s.Value) {
                    case 'e': return s.TransitionTo(State.K_package);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_package,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("package"));
                    case (char)0: return s.Returns(new Keyword("package"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.M_pr_private_or_protected,
                s =>  { 
                    switch(s.Value) {
                    case 'i': return s.TransitionTo(State.K_pri_private);
                    case 'o': return s.TransitionTo(State.K_pro_protected);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_pri_private,
                s =>  { 
                    switch(s.Value) {
                    case 'v': return s.TransitionTo(State.K_priv_private);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_priv_private,
                s =>  { 
                    switch(s.Value) {
                    case 'a': return s.TransitionTo(State.K_priva_private);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_priva_private,
                s =>  { 
                    switch(s.Value) {
                    case 't': return s.TransitionTo(State.K_privat_private);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_privat_private,
                s =>  { 
                    switch(s.Value) {
                    case 'e': return s.TransitionTo(State.K_private);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_private,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("private"));
                    case (char)0: return s.Returns(new Keyword("private"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_pro_protected,
                s =>  { 
                    switch(s.Value) {
                    case 't': return s.TransitionTo(State.K_prot_protected);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_prot_protected,
                s =>  { 
                    switch(s.Value) {
                    case 'e': return s.TransitionTo(State.K_prote_protected);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_prote_protected,
                s =>  { 
                    switch(s.Value) {
                    case 'c': return s.TransitionTo(State.K_protec_protected);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_protec_protected,
                s =>  { 
                    switch(s.Value) {
                    case 't': return s.TransitionTo(State.K_protect_protected);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_protect_protected,
                s =>  { 
                    switch(s.Value) {
                    case 'e': return s.TransitionTo(State.K_protecte_protected);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_protecte_protected,
                s =>  { 
                    switch(s.Value) {
                    case 'd': return s.TransitionTo(State.K_protected);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_protected,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("protected"));
                    case (char)0: return s.Returns(new Keyword("protected"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.M_r_readonly_or_return,
                s =>  { 
                    switch(s.Value) {
                    case 'e': return s.TransitionTo(State.M_re_readonly_or_return);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.M_re_readonly_or_return,
                s =>  { 
                    switch(s.Value) {
                    case 'a': return s.TransitionTo(State.K_rea_readonly);
                    case 't': return s.TransitionTo(State.K_ret_return);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_rea_readonly,
                s =>  { 
                    switch(s.Value) {
                    case 'd': return s.TransitionTo(State.K_read_readonly);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_read_readonly,
                s =>  { 
                    switch(s.Value) {
                    case 'o': return s.TransitionTo(State.K_reado_readonly);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_reado_readonly,
                s =>  { 
                    switch(s.Value) {
                    case 'n': return s.TransitionTo(State.K_readon_readonly);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_readon_readonly,
                s =>  { 
                    switch(s.Value) {
                    case 'l': return s.TransitionTo(State.K_readonl_readonly);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_readonl_readonly,
                s =>  { 
                    switch(s.Value) {
                    case 'y': return s.TransitionTo(State.K_readonly);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_readonly,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("readonly"));
                    case (char)0: return s.Returns(new Keyword("readonly"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_ret_return,
                s =>  { 
                    switch(s.Value) {
                    case 'u': return s.TransitionTo(State.K_retu_return);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_retu_return,
                s =>  { 
                    switch(s.Value) {
                    case 'r': return s.TransitionTo(State.K_retur_return);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_retur_return,
                s =>  { 
                    switch(s.Value) {
                    case 'n': return s.TransitionTo(State.K_return);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_return,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("return"));
                    case (char)0: return s.Returns(new Keyword("return"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_s_sealed,
                s =>  { 
                    switch(s.Value) {
                    case 'e': return s.TransitionTo(State.K_se_sealed);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_se_sealed,
                s =>  { 
                    switch(s.Value) {
                    case 'a': return s.TransitionTo(State.K_sea_sealed);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_sea_sealed,
                s =>  { 
                    switch(s.Value) {
                    case 'l': return s.TransitionTo(State.K_seal_sealed);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_seal_sealed,
                s =>  { 
                    switch(s.Value) {
                    case 'e': return s.TransitionTo(State.K_seale_sealed);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_seale_sealed,
                s =>  { 
                    switch(s.Value) {
                    case 'd': return s.TransitionTo(State.K_sealed);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_sealed,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("sealed"));
                    case (char)0: return s.Returns(new Keyword("sealed"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.M_t_this_or_throw_or_trait_or_true_or_try_or_type,
                s =>  { 
                    switch(s.Value) {
                    case 'h': return s.TransitionTo(State.M_th_this_or_throw);
                    case 'r': return s.TransitionTo(State.M_tr_trait_or_true_or_try);
                    case 'y': return s.TransitionTo(State.K_ty_type);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.M_th_this_or_throw,
                s =>  { 
                    switch(s.Value) {
                    case 'i': return s.TransitionTo(State.K_thi_this);
                    case 'r': return s.TransitionTo(State.K_thr_throw);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_thi_this,
                s =>  { 
                    switch(s.Value) {
                    case 's': return s.TransitionTo(State.K_this);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_this,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("this"));
                    case (char)0: return s.Returns(new Keyword("this"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_thr_throw,
                s =>  { 
                    switch(s.Value) {
                    case 'o': return s.TransitionTo(State.K_thro_throw);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_thro_throw,
                s =>  { 
                    switch(s.Value) {
                    case 'w': return s.TransitionTo(State.K_throw);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_throw,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("throw"));
                    case (char)0: return s.Returns(new Keyword("throw"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.M_tr_trait_or_true_or_try,
                s =>  { 
                    switch(s.Value) {
                    case 'a': return s.TransitionTo(State.K_tra_trait);
                    case 'u': return s.TransitionTo(State.K_tru_true);
                    case 'y': return s.TransitionTo(State.K_try);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_tra_trait,
                s =>  { 
                    switch(s.Value) {
                    case 'i': return s.TransitionTo(State.K_trai_trait);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_trai_trait,
                s =>  { 
                    switch(s.Value) {
                    case 't': return s.TransitionTo(State.K_trait);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_trait,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("trait"));
                    case (char)0: return s.Returns(new Keyword("trait"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_tru_true,
                s =>  { 
                    switch(s.Value) {
                    case 'e': return s.TransitionTo(State.K_true);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_true,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("true"));
                    case (char)0: return s.Returns(new Keyword("true"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_try,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("try"));
                    case (char)0: return s.Returns(new Keyword("try"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_ty_type,
                s =>  { 
                    switch(s.Value) {
                    case 'p': return s.TransitionTo(State.K_typ_type);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_typ_type,
                s =>  { 
                    switch(s.Value) {
                    case 'e': return s.TransitionTo(State.K_type);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_type,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("type"));
                    case (char)0: return s.Returns(new Keyword("type"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.M_v_val_or_var,
                s =>  { 
                    switch(s.Value) {
                    case 'a': return s.TransitionTo(State.M_va_val_or_var);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.M_va_val_or_var,
                s =>  { 
                    switch(s.Value) {
                    case 'l': return s.TransitionTo(State.K_val);
                    case 'r': return s.TransitionTo(State.K_var);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_val,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("val"));
                    case (char)0: return s.Returns(new Keyword("val"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_var,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("var"));
                    case (char)0: return s.Returns(new Keyword("var"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.M_w_while_or_with,
                s =>  { 
                    switch(s.Value) {
                    case 'h': return s.TransitionTo(State.K_wh_while);
                    case 'i': return s.TransitionTo(State.K_wi_with);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_wh_while,
                s =>  { 
                    switch(s.Value) {
                    case 'i': return s.TransitionTo(State.K_whi_while);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_whi_while,
                s =>  { 
                    switch(s.Value) {
                    case 'l': return s.TransitionTo(State.K_whil_while);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_whil_while,
                s =>  { 
                    switch(s.Value) {
                    case 'e': return s.TransitionTo(State.K_while);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_while,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("while"));
                    case (char)0: return s.Returns(new Keyword("while"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_wi_with,
                s =>  { 
                    switch(s.Value) {
                    case 't': return s.TransitionTo(State.K_wit_with);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_wit_with,
                s =>  { 
                    switch(s.Value) {
                    case 'h': return s.TransitionTo(State.K_with);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_with,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("with"));
                    case (char)0: return s.Returns(new Keyword("with"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_y_yield,
                s =>  { 
                    switch(s.Value) {
                    case 'i': return s.TransitionTo(State.K_yi_yield);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_yi_yield,
                s =>  { 
                    switch(s.Value) {
                    case 'e': return s.TransitionTo(State.K_yie_yield);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_yie_yield,
                s =>  { 
                    switch(s.Value) {
                    case 'l': return s.TransitionTo(State.K_yiel_yield);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_yiel_yield,
                s =>  { 
                    switch(s.Value) {
                    case 'd': return s.TransitionTo(State.K_yield);
                    case ' ': return s.Returns(new Identifier(s.Buffer));
                    case (char)0: return s.Returns(new Identifier(s.Buffer));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
            { 
                State.K_yield,
                s =>  { 
                    switch(s.Value) {
                    case ' ': return s.Returns(new Keyword("yield"));
                    case (char)0: return s.Returns(new Keyword("yield"));
                    default: return s.TransitionTo(State.Identifier);
                    }
                }
            },
        };
    }
}