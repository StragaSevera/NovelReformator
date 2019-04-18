using System;
using System.Collections.Generic;
using NovelReformatorCore.AbstractSyntaxTree;

namespace NovelReformatorCore.FanficsMe
{
    public class Parser
    {
        // Надо бы DI-ть, но влом
        private readonly IReadOnlyList<Token> _tokens;
        private int _currentPosition;
        private Token CurrentToken => _tokens[_currentPosition];

        public Parser(string text)
        {
            _tokens = new Lexer(text).GetTokenList();
        }

        public AbstractNode Parse()
        {
            AbstractNode tree = Chunk();
            Consume(TokenType.EOF);
            return tree;
        }

        private ChunkNode Chunk()
        {
            var children = new List<AbstractNode>();
            while (CurrentToken.Type == TokenType.Text || CurrentToken.Type == TokenType.TagOpen)
            {
                // ReSharper disable once SwitchStatementMissingSomeCases
                switch (CurrentToken.Type)
                {
                    case TokenType.Text:
                        children.Add(new TextNode(CurrentToken.Value));
                        Consume(TokenType.Text);
                        break;
                    case TokenType.TagOpen:
                        children.Add(Tag());
                        break;
                }
            }

            return new ChunkNode(children);
        }

        private AbstractTagNode Tag()
        {
            var tagName = CurrentToken.Value;
            Consume(TokenType.TagOpen);
            if (IsTagSingle(tagName))
            {
                // TODO: Add single tag handling
                return new UnknownTagNode(tagName, null);
            }

            ChunkNode tagContent = Chunk();
            if (tagName != CurrentToken.Value)
            {
                throw new ParsingException(
                    $"Error: tag name mismatch, expecting closing tag {tagName}, found {CurrentToken.Value}");
            }

            Consume(TokenType.TagClose);
            // TODO: Refactor ugly switch
            switch (tagName)
            {
                case "b": return new BoldNode(tagContent);
                case "i": return new ItalicNode(tagContent);
                case "u": return new UnderlineNode(tagContent);
                case "s": return new StrikeNode(tagContent);
                case "center": return new CenterNode(tagContent);
                case "right": return new RightNode(tagContent);
                case "note": return new NoteNode(tagContent);
                default: return new UnknownTagNode(tagName, tagContent);
            }
        }

        private bool IsTagSingle(string tagName)
        {
            return false;
        }

        private void Consume(TokenType tokenType)
        {
            if (CurrentToken.Type == tokenType)
            {
                _currentPosition++;
            }
            else
            {
                throw new ParsingException($"Error: trying to consume {tokenType}, found {CurrentToken.Type}");
            }
        }
    }
}