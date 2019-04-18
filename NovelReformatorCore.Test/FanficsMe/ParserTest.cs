using System;
using System.Collections.Generic;
using NovelReformatorCore;
using NovelReformatorCore.AbstractSyntaxTree;
using NovelReformatorCore.FanficsMe;
using NUnit.Framework;

namespace NovelReformatorCoreTest.FanficsMe
{
    [TestFixture]
    public class ParserTest
    {
        [Test]
        public void ParsesEmptyBlock()
        {
            var parser = new Parser("");
            AbstractNode tree = parser.Parse();
            Assert.That(tree, Is.TypeOf(typeof(ChunkNode)));
            var treeChunk = (ChunkNode) tree;
            Assert.That(treeChunk.Children.Count, Is.EqualTo(0));
        }

        [Test]
        public void ParsesTextBlock()
        {
            var parser = new Parser("Text");
            AbstractNode tree = parser.Parse();
            Assert.That(tree, Is.TypeOf(typeof(ChunkNode)));
            var treeChunk = (ChunkNode) tree;
            Assert.That(treeChunk.Children, Is.EqualTo(new List<AbstractNode>
            {
                new TextNode("Text")
            }));
        }

        [Test]
        public void ParsesTagBlock()
        {
            var parser = new Parser("<tag>Text</tag>");
            AbstractNode tree = parser.Parse();
            Assert.That(tree, Is.TypeOf(typeof(ChunkNode)));
            var treeChunk = (ChunkNode) tree;
            Assert.That(treeChunk.Children, Is.EqualTo(new List<AbstractNode>
            {
                new UnknownTagNode("tag", new ChunkNode(new List<AbstractNode>{new TextNode("Text")}))
            }));
        }

        [Test]
        public void ParsesComplexBlock()
        {
            var parser = new Parser("Header: <center>A <b>Test</b> Header</center>");
            AbstractNode tree = parser.Parse();
            Assert.That(tree, Is.TypeOf(typeof(ChunkNode)));
            var treeChunk = (ChunkNode) tree;
            Assert.That(treeChunk.Children, Is.EqualTo(new List<AbstractNode>
            {
                new TextNode("Header: "),
                new CenterNode(new ChunkNode(new List<AbstractNode>
                {
                    new TextNode("A "),
                    new BoldNode(new ChunkNode(new List<AbstractNode>{new TextNode("Test")})),
                    new TextNode(" Header")
                }))
            }));
        }

        [Test]
        public void ThrowsErrorOnTagMismatch()
        {
            var parser = new Parser("<tag>Text</wrong>");
            Assert.Throws<ParsingException>(() => parser.Parse());
        }

        [Test]
        public void ThrowsErrorOnWrongConsume()
        {
            var parser = new Parser("Text</wrong>");
            Assert.Throws<ParsingException>(() => parser.Parse());
        }
    }
}