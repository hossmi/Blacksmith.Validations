using Blacksmith.Validations.Exceptions;
using System;

namespace Blacksmith.Validations.Tests.SampleDomain.Exceptions
{
    [Serializable]
    public class OddExpectedVehicleWheelsDomainException : DomainException
    {
        public OddExpectedVehicleWheelsDomainException(int tried)
        {
            this.Tried = tried;
        }

        public int Tried { get; }
    }
}