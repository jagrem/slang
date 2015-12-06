using System.Collections.Generic;

namespace slang.Lexing.Tokens.Constants
{
    public static class Punctuation
    {
        public static IEnumerable<TokenInfo> GetAllPunctuation()
        {
            return new[] {
                new TokenInfo("ampersand", "&"),
                new TokenInfo("apostrophe", "'"),
                new TokenInfo("asterisk", "*"),
                new TokenInfo("at", "@"),
                new TokenInfo("back_slash", "\\"),
                new TokenInfo("caret", "^"),
                new TokenInfo("colon", ":"),
                new TokenInfo("comma", ","),
                new TokenInfo("dollar_sign", "$"),
                new TokenInfo("equals", "="),
                new TokenInfo("exclamation_mark", "!"),
                new TokenInfo("forward_slash", "/"),
                new TokenInfo("hyphen", "-"),
                new TokenInfo("left_angle_bracket", "<"),
                new TokenInfo("left_brace", "{"),
                new TokenInfo("left_parenthesis", "("),
                new TokenInfo("left_square_bracket", "["),
                new TokenInfo("modulus", "%"),
                new TokenInfo("octothorpe", "#"),
                new TokenInfo("pipe", "|"),
                new TokenInfo("plus", "+"),
                new TokenInfo("question_mark", "?"),
                new TokenInfo("right_angle_bracket", ">"),
                new TokenInfo("right_brace", "}"),
                new TokenInfo("right_parenthesis", ")"),
                new TokenInfo("right_square_bracket", "]"),
                new TokenInfo("semicolon", ";"),
                new TokenInfo("tilde", "~"),
                new TokenInfo("underscore", "_"),
            };
        }
    }
}

