using System;
using Blacksmith.Validations.Exceptions;
using Blacksmith.Validations.Tests.SampleDomain;
using NUnit.Framework;

namespace Blacksmith.Validations.Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            IVehicleService vehicleService;
            IDomainStrings domainStrings;
            IVehicle car;

            domainStrings = new EsDomainStrings();
            vehicleService = new VehicleService(domainStrings);

            car = vehicleService.createVehicle("ABC1234");
            car.Plate = "XXX0000";

            Assert.Throws<DomainException>(() => car.Plate = "12345678901234567890123456789012345678901");
        }
    }
}