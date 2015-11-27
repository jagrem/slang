namespace slang.Lexing
{
    enum State {
        Zero,
        Empty,
        Error,

        Identifier,

        // class
        K_c_class, K_cl_class, K_cla_class, K_clas_class, K_class,

        // def
        K_d_def, K_de_def, K_def,

        // false
        S_f_false, S_fa_false, S_fal_false, S_fals_false, S_false,

        // interface
        K_i_interface, K_in_interface, K_int_interface, K_inte_interface, K_inter_interface, K_interf_interface, K_interfa_interface, K_interfac_interface, K_interface,

        // true or trait
        M_t_true_or_trait, M_tr_true_or_trait,
        S_t_true, S_tr_true, S_tru_true, S_true,
        K_tra_trait, K_trai_trait, K_trait,

        // val or var
        M_v_val_or_var, M_va_val_or_var,
        K_val,
        K_var,

        // numbers
        S_number,
        S_number_zero,
        S_number_and_hexadecimal_specifier,
        S_hexadecimal_number,
        S_signed_exponent_and_number_with_specifier,
        S_signed_exponent_and_number, 
        S_number_with_signed_exponent,
        S_number_with_exponent,
        S_number_with_real_specifier,
        S_number_with_integer_specifier,
        S_number_with_unsigned_specifier,
        S_number_with_unsigned_integer_specifier,
        S_decimal_point_and_number,
        S_number_and_decimal_point,
    }
    
}
