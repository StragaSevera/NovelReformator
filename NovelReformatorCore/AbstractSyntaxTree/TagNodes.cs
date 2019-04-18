namespace NovelReformatorCore.AbstractSyntaxTree
{
    public abstract class AbstractTagNode : AbstractNode
    {
        public string Name { get; }
        public ChunkNode Content { get; }

        public AbstractTagNode(string name, ChunkNode content)
        {
            Name = name;
            Content = content;
        }

        private bool Equals(AbstractTagNode other)
        {
            return string.Equals(Name, other.Name) && Equals(Content, other.Content);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((AbstractTagNode) obj);
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

    public class BoldNode : AbstractTagNode
    {
        public BoldNode(ChunkNode content) : base("b", content)
        {
        }
    }

    public class ItalicNode : AbstractTagNode
    {
        public ItalicNode(ChunkNode content) : base("i", content)
        {
        }
    }

    public class UnderlineNode : AbstractTagNode
    {
        public UnderlineNode(ChunkNode content) : base("u", content)
        {
        }
    }

    public class StrikeNode : AbstractTagNode
    {
        public StrikeNode(ChunkNode content) : base("s", content)
        {
        }
    }

    public class CenterNode : AbstractTagNode
    {
        public CenterNode(ChunkNode content) : base("center", content)
        {
        }
    }

    public class RightNode : AbstractTagNode
    {
        public RightNode(ChunkNode content) : base("right", content)
        {
        }
    }

    public class NoteNode : AbstractTagNode
    {
        public NoteNode(ChunkNode content) : base("note", content)
        {
        }
    }

    public class UnknownTagNode : AbstractTagNode
    {
        public UnknownTagNode(string name, ChunkNode content) : base(name, content)
        {
        }
    }
}