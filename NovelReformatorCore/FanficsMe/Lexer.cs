using System;
using System.Collections.Generic;
using System.Text;

namespace NovelReformatorCore.FanficsMe
{
    public class Lexer
    {
        public string Text { get; }
        private int _currentPosition;
        private char? CurrentChar => _currentPosition < Text.Length ? Text[_currentPosition] : null as char?;
        private char? NextChar => _currentPosition < Text.Length - 1 ? Text[_currentPosition] : null as char?;

        public Lexer(string text)
        {
            Text = text;
        }

        public IReadOnlyList<Token> GetTokenList()
        {
            var tokenList = new List<Token>();
            Token currentToken;
            do
            {
                currentToken = GetNextToken();
                tokenList.Add(currentToken);
            } while (currentToken.Type != TokenType.EOF);

            return tokenList;
        }

        private Token GetNextToken()
        {
            Token token;
            if (CurrentChar is null)
            {
                token = new Token(TokenType.EOF);
            }
            else if (IsTagStart())
            {
                token = GetTagToken();
            }
            else
            {
                token = GetChunkToken();
            }
            return token;
        }

        private Token GetTagToken()
        {
            var value = new StringBuilder();
            Advance();
            var type = TokenType.TagOpen;
            if (CurrentChar == '/')
            {
                type = TokenType.TagClose;
                Advance();
            }
            while (CurrentChar != null && CurrentChar != '>')
            {
                value.Append(CurrentChar);
                Advance();
            }
            Advance();
            return new Token(type, value.ToString());
        }

        private Token GetChunkToken()
        {
            var value = new StringBuilder();
            while (CurrentChar != null && !IsTagStart())
            {
                value.Append(CurrentChar);
                Advance();
            }

            return new Token(TokenType.Text, value.ToString());
        }

        private bool IsTagStart()
        {
            return CurrentChar == '<' && NextChar != null && !char.IsWhiteSpace((char) NextChar);
        }


        private void Advance()
        {
            _currentPosition++;
        }
    }
}