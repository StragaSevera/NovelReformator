using NoverLeformatorCore.FanficsMe;
using NUnit.Framework;

namespace NovelReformatorCoreTest.FanficsMe
{
    [TestFixture]
    public class TokenTest
    {
        [Test]
        public void ItExists()
        {
            var token = new Token(TokenType.Tag, "center");
            Assert.That(token, Is.Not.Null);

        }
    }
}