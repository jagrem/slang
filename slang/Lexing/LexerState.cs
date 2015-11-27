using slang.Lexing.Tokens;

namespace slang.Lexing
{
    class LexerState {
        public char Value { get; set; }
        public string Buffer { get; set; }
        public State State { get; set; }
        public Token Token { get; set; }


    }
}
