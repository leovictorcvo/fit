using System;
using System.Runtime.Serialization;

namespace Backend.Domain.Exceptions
{
    [Serializable]
    public class InsufficientStockException : Exception
    {
        public InsufficientStockException()
        {
        }

        public InsufficientStockException(string message)
            : base(message)
        {
        }

        public InsufficientStockException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected InsufficientStockException(SerializationInfo info, StreamingContext context)
           : base(info, context)
        {
        }
    }
}
