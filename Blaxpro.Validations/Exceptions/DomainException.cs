using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Blaxpro.Validations.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        {
        }

        public DomainException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DomainException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public static implicit operator DomainException(string message)
        {
            return new DomainException(message);
        }
    }
}