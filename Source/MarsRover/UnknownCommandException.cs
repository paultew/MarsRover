using System;

namespace MarsRover
{
    [Serializable]
    public class UnknownCommandException : Exception
    {
        public UnknownCommandException(string message)
            : base(message)
        {
        }

        public UnknownCommandException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected UnknownCommandException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}
