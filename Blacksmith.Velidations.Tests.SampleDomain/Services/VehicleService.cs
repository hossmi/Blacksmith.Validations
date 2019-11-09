using Blacksmith.Velidations.Tests.SampleDomain.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace Blacksmith.Validations.Tests.SampleDomain.Services
{
    public class VehicleService : AbstractSampleDomain, IVehicleService
    {
        public VehicleService() : base()
        {
        }

        public IEnumerable<Vehicle> getVehiclesContainingPlate(string plate)
        {
            stringIsNotEmpty<VehiclesRequestDomainException>(plate);

            return getVehicles()
                .Where(v => v.Plate.Contains(plate));
        }

        private static IEnumerable<Vehicle> getVehicles()
        {
            yield return new Vehicle("XYZ1000", 4, "Seat");
            yield return new Vehicle("BBB2000", 4, "BMW");
            yield return new Vehicle("CCC3000", 6, "Iveco");
            yield return new Vehicle("DDD4000", 10, "Man Trucks");
            yield return new Vehicle("EEE5000", 4, "Audi");
        }
    }
}