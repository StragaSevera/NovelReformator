namespace NovelReformatorCore.FanficsMe
{
    public enum TokenType
    {
        TagOpen,
        TagClose,
        EOF,
        Text
    }

    public struct Token
    {
        public TokenType Type { get; }
        public string Value { get; } // Пока строка, потом посмотрим

        public Token(TokenType type)
        {
            Type = type;
            Value = "";
        }

        public Token(TokenType type, string value)
        {
            Type = type;
            Value = value;
        }

        public override string ToString()
        {
            return $"{Type.ToString()}: {Value}";
        }
    }
}