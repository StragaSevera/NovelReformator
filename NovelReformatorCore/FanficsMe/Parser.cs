using System;
using System.Collections.Generic;
using NovelReformatorCore.AbstractSyntaxTree;

namespace NovelReformatorCore.FanficsMe
{
    public class Parser
    {
        // Надо бы DI-ть, но влом
        private readonly IReadOnlyList<Token> _tokens;
        private int _currentPosition = 0;
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

        private TagNode Tag()
        {
            var tagName = CurrentToken.Value;
            Consume(TokenType.TagOpen);
            ChunkNode tagContent = Chunk();
            if (tagName != CurrentToken.Value)
            {
                throw new ParsingException($"Error: tag name mismatch, expecting closing tag {tagName}, found {CurrentToken.Value}");
            }
            Consume(TokenType.TagClose);
            return new TagNode(tagName, tagContent);
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