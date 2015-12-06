using slang.Lexing.Tokens;

namespace slang.Lexing.Extensions
{
    static class LexerStateExtensions 
    {
        public static LexerState TransitionTo(this LexerState lexerState, State state)
        {
            return new LexerState { Token = Token.Empty, State = state, Buffer = lexerState.Buffer + lexerState.Value, Value = lexerState.Value };
        }

        public static LexerState TransitionTo(this LexerState lexerState, State state, string buffer)
        {
            return new LexerState { Token = Token.Empty, State = state, Buffer = buffer, Value = lexerState.Value };
        }

        public static LexerState ToError(this LexerState lexerState) {
            return new LexerState { Token = new Error("Received: " + lexerState.Buffer + lexerState.Value), State = State.Error, Buffer = lexerState.Buffer + lexerState.Value, Value = lexerState.Value };
        }

        public static LexerState Returns(this LexerState lexerState, Token token)
        {
            return new LexerState { Token = token, State = State.Zero, Buffer = string.Empty, Value = lexerState.Value };
        }
    }
    
}
