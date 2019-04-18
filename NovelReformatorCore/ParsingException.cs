using System;
using System.Runtime.Serialization;

namespace NovelReformatorCore
{
    public class ParsingException : Exception
    {
        public ParsingException()
        {
        }

        protected ParsingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ParsingException(string message) : base(message)
        {
        }

        public ParsingException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}