using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NovelReformatorCore.AbstractSyntaxTree
{
    public abstract class AbstractNode
    {

    }

    public class ChunkNode : AbstractNode
    {
        public IReadOnlyList<AbstractNode> Children { get; }

        public ChunkNode(IReadOnlyList<AbstractNode> children)
        {
            Children = children;
        }

        // Добавляю сравнение на равенство для удобства тестинга,
        // хоть это и плохо
        private bool Equals(ChunkNode other)
        {
            return Children.SequenceEqual(other.Children);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((ChunkNode) obj);
        }

        public override int GetHashCode()
        {
            return Children != null ? Children.GetHashCode() : 0;
        }

        public override string ToString()
        {
            var builder = new StringBuilder("ChunkNode: [");
            foreach (AbstractNode child in Children)
            {
                builder.Append(child);
                builder.Append(", \n");
            }
            builder.Append("]");
            return builder.ToString();
        }
    }

    public class TextNode : AbstractNode
    {
        public string Content { get; }

        public TextNode(string content)
        {
            Content = content;
        }

        private bool Equals(TextNode other)
        {
            return string.Equals(Content, other.Content);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((TextNode) obj);
        }

        public override int GetHashCode()
        {
            return Content != null ? Content.GetHashCode() : 0;
        }

        public override string ToString()
        {
            return $"TextNode: \"{Content}\"";
        }
    }

    public class TagNode : AbstractNode
    {
        public string Name { get; }
        public ChunkNode Content { get; }

        public TagNode(string name, ChunkNode content)
        {
            Name = name;
            Content = content;
        }

        private bool Equals(TagNode other)
        {
            return string.Equals(Name, other.Name) && Equals(Content, other.Content);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((TagNode) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0) * 397) ^ (Content != null ? Content.GetHashCode() : 0);
            }
        }

        public override string ToString()
        {
            return $"TagNode: <{Name}>{Content}</{Name}>";
        }
    }
}