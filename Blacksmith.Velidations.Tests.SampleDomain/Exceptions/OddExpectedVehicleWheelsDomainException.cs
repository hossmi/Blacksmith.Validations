using Blacksmith.Validations.Exceptions;
using System;

namespace Blacksmith.Velidations.Tests.SampleDomain.Exceptions
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