using Blacksmith.Validations.Tests.SampleDomain.Exceptions;
using System.Text.RegularExpressions;

namespace Blacksmith.Validations.Tests.SampleDomain
{
    public abstract class AbstractSampleDomain : AbstractDomain
    {
        private static readonly Regex plateRegex =
            new Regex(@"[A-Z]{3}[0-9]{4}",
                RegexOptions.Compiled
                | RegexOptions.CultureInvariant
                | RegexOptions.Singleline);

        protected void plateIsValid(string plate)
        {
            stringIsNotEmpty<VehiclePlateDomainException>(plate);
            stringMatchRegex<VehiclePlateDomainException>(plate, plateRegex);
            stringMaxLength<VehiclePlateDomainException>(plate, 10);
        }

        protected void validateVehicleWheels(int wheels)
        {
            isTrue(0 < wheels && wheels <= 28, () => new OutOfRangeVehicleWheelsDomainException(
                minimumAllowedWheels: 0, maximumAllowedWheels: 28, tried: wheels));

            isTrue(wheels % 2 == 0, () => new OddExpectedVehicleWheelsDomainException(tried: wheels));
        }


    }
}