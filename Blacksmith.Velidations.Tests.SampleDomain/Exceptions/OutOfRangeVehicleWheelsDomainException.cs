using Blacksmith.Validations.Exceptions;
using System;

namespace Blacksmith.Velidations.Tests.SampleDomain.Exceptions
{
    [Serializable]
    public class OutOfRangeVehicleWheelsDomainException : DomainException
    {
        public OutOfRangeVehicleWheelsDomainException(int minimumAllowedWheels, int maximumAllowedWheels, int tried)
        {
            this.MinimumAllowedWheels = minimumAllowedWheels;
            this.MaximumAllowedWheels = maximumAllowedWheels;
            this.Tried = tried;
        }

        public int MinimumAllowedWheels { get; }
        public int MaximumAllowedWheels { get; }
        public int Tried { get; }
    }
}