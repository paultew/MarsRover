using System;

namespace MarsRover
{
    [Serializable]
    public class InvalidPositionException : Exception
    {
        public InvalidPositionException(string message)
            : base(message)
        {
        }

        public InvalidPositionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected InvalidPositionException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}
