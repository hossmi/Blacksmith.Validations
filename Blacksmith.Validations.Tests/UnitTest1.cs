using Blacksmith.Validations.Exceptions;
using Blacksmith.Validations.Tests.SampleDomain;
using Blacksmith.Validations.Tests.SampleDomain.Services;
using Blacksmith.Velidations.Tests.SampleDomain.Exceptions;
using NUnit.Framework;

namespace Blacksmith.Validations.Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            IVehicleService vehicleService;
            Vehicle car;

            vehicleService = new VehicleService();

            car = new Vehicle("ABC1234", 4, "Seat");
            car.Plate = "XXX0000";

            Assert.Throws<VehiclePlateDomainException>(() => car.Plate = "12345678901234567890123456789012345678901");
        }

        [Test]
        public void test_asserts()
        {
            IValidator a;
            SampleEnum sampleEnum;

            a = Asserts.Default;

            Assert.Throws<FailAssertException>(() => a.fail());

            a.isFalse(false);
            Assert.Throws<FalseExpectedAssertException>(() => a.isFalse(true));

            a.isTrue(true);
            Assert.Throws<TrueExpectedAssertException>(() => a.isTrue(false));

            a.isInstanceOf<IValidator>(a);
            Assert.Throws<ExpectedTypeAssertException>(() => a.isInstanceOf<IValidator>(this));

            a.isNotNull(a);
            Assert.Throws<NotNullExpectedObjectAssertException>(() => a.isNotNull<IValidator>(null));

            a.isNull<IValidator>(null);
            Assert.Throws<NullExpectedObjectAssertException>(() => a.isNull(a));

            sampleEnum = SampleEnum.Three;
            a.isValidEnum(sampleEnum);
            Assert.Throws<ValidEnumValueExpectedAssertException>(() => a.isValidEnum((SampleEnum)55));
        }
    }
}