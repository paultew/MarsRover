using System;

namespace MarsRover
{
    [Serializable]
    public class InvalidDimensionsException : Exception
    {
        public InvalidDimensionsException(string message)
            : base(message)
        {
        }

        public InvalidDimensionsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected InvalidDimensionsException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}
