using System;
using System.Runtime.Serialization;
using Blacksmith.Validations.Exceptions;

namespace Blacksmith.Velidations.Tests.SampleDomain.Exceptions
{
    [Serializable]
    public class VehiclePlateDomainException : DomainException
    {
        public VehiclePlateDomainException()
        {
        }

        protected VehiclePlateDomainException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}