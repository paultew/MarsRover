using System;

namespace MarsRover
{
    [Serializable]
    public class InvalidLocationException : Exception
    {
        public InvalidLocationException(string message)
            : base(message)
        {
        }

        public InvalidLocationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected InvalidLocationException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}
