using NovelReformatorCore.FanficsMe;
using NUnit.Framework;

namespace NovelReformatorCoreTest.FanficsMe
{
    [TestFixture]
    public class TokenTest
    {
        [Test]
        public void StoresTypeAndValue()
        {
            var token = new Token(TokenType.TagOpen, "center");
            Assert.That(token.Type, Is.EqualTo(TokenType.TagOpen));
            Assert.That(token.Value, Is.EqualTo("center"));
        }
    }
}