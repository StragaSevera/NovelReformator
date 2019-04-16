using System.Collections.Generic;
using NovelReformatorCore.FanficsMe;
using NUnit.Framework;

namespace NovelReformatorCoreTest.FanficsMe
{
    [TestFixture]
    public class LexerTest
    {
        [Test]
        public void StoresText()
        {
            var lexer = new Lexer("Test");
            Assert.That(lexer.Text, Is.EqualTo("Test"));
        }

        [Test]
        public void GivesEOFTokenList()
        {
            var lexer = new Lexer("");
            var list = lexer.GetTokenList();
            Assert.That(list, Is.EqualTo(new List<Token>
            {
                new Token(TokenType.EOF)
            }));
        }

        [Test]
        public void GivesOneTextTokenList()
        {
            var lexer = new Lexer("test");
            var list = lexer.GetTokenList();
            Assert.That(list, Is.EqualTo(new List<Token>
            {
                new Token(TokenType.Text, "test"),
                new Token(TokenType.EOF)
            }));
        }

        [Test]
        public void GivesTagStartTokenList()
        {
            var lexer = new Lexer("<test>");
            var list = lexer.GetTokenList();
            Assert.That(list, Is.EqualTo(new List<Token>
            {
                new Token(TokenType.TagOpen, "test"),
                new Token(TokenType.EOF)
            }));
        }

        [Test]
        public void GivesTagTextTokenList()
        {
            var lexer = new Lexer("<test>string</test>");
            var list = lexer.GetTokenList();
            Assert.That(list, Is.EqualTo(new List<Token>
            {
                new Token(TokenType.TagOpen, "test"),
                new Token(TokenType.Text, "string"),
                new Token(TokenType.TagClose, "test"),
                new Token(TokenType.EOF)
            }));
        }

        [Test]
        public void GivesBigTextTokenList()
        {
            var lexer = new Lexer("Header: <center>A <b>Test</b> Header</center>");
            var list = lexer.GetTokenList();
            Assert.That(list, Is.EqualTo(new List<Token>
            {
                new Token(TokenType.Text, "Header: "),
                new Token(TokenType.TagOpen, "center"),
                new Token(TokenType.Text, "A "),
                new Token(TokenType.TagOpen, "b"),
                new Token(TokenType.Text, "Test"),
                new Token(TokenType.TagClose, "b"),
                new Token(TokenType.Text, " Header"),
                new Token(TokenType.TagClose, "center"),
                new Token(TokenType.EOF)
            }));
        }

        [Test]
        public void GivesBadTextTokenList()
        {
            var lexer = new Lexer("Header: </b>A <b>Test</center> Header</center>");
            var list = lexer.GetTokenList();
            Assert.That(list, Is.EqualTo(new List<Token>
            {
                new Token(TokenType.Text, "Header: "),
                new Token(TokenType.TagClose, "b"),
                new Token(TokenType.Text, "A "),
                new Token(TokenType.TagOpen, "b"),
                new Token(TokenType.Text, "Test"),
                new Token(TokenType.TagClose, "center"),
                new Token(TokenType.Text, " Header"),
                new Token(TokenType.TagClose, "center"),
                new Token(TokenType.EOF)
            }));
        }
    }
}