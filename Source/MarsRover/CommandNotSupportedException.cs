using System;

namespace MarsRover
{
    [Serializable]
    public class CommandNotSupportedException : Exception
    {
        public CommandNotSupportedException(string message)
            : base(message)
        {
        }

        public CommandNotSupportedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected CommandNotSupportedException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}
