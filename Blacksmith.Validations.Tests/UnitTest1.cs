using Blacksmith.Validations.Exceptions;
using Blacksmith.Validations.Tests.SampleDomain;
using Blacksmith.Validations.Tests.SampleDomain.Exceptions;
using Blacksmith.Validations.Tests.SampleDomain.Services;
using NUnit.Framework;
using FluentAssertions;

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
        public void test_fail()
        {
            IValidator a;

            a = Asserts.Default;

            Assert.Throws<FailAssertException>(() => a.fail());
        }

        [Test]
        public void test_isFalse()
        {
            IValidator a;

            a = Asserts.Default;

            a.isFalse(false);
            Assert.Throws<FalseExpectedAssertException>(() => a.isFalse(true));
        }

        [Test]
        public void test_istrue()
        {
            IValidator a;

            a = Asserts.Default;

            a.isTrue(true);
            Assert.Throws<TrueExpectedAssertException>(() => a.isTrue(false));
        }

        [Test]
        public void test_isInstanceOf()
        {
            IValidator a;

            a = Asserts.Default;

            a.isInstanceOf<IValidator>(a);
            Assert.Throws<ExpectedTypeAssertException>(() => a.isInstanceOf<IValidator>(this));
        }

        [Test]
        public void test_isNotNull()
        {
            IValidator a;
            a = Asserts.Default;

            a.isNotNull(a);
            Assert.Throws<NotNullExpectedObjectAssertException>(() => a.isNotNull<IValidator>(null));
        }

        [Test]
        public void test_isNull()
        {
            IValidator a;

            a = Asserts.Default;

            a.isNull<IValidator>(null);
            Assert.Throws<NullExpectedObjectAssertException>(() => a.isNull(a));
        }

        [Test]
        public void test_isValidEnum()
        {
            IValidator a;
            SampleEnum sampleEnum;

            a = Asserts.Default;

            sampleEnum = SampleEnum.Three;
            a.isValidEnum(sampleEnum);
            Assert.Throws<ValidEnumValueExpectedAssertException>(() => a.isValidEnum((SampleEnum)55));
        }

        [Test]
        public void test_isValidEnumeration()
        {
            IValidator a;
            SampleEnumeration sampleEnumeration;

            a = Asserts.Default;

            sampleEnumeration = SampleEnumeration.Two;
            a.isValidEnumeration(sampleEnumeration);
            Assert.Throws<ValidEnumerationObjectExpectedAssertException>(() => 
                a.isValidEnumeration<SampleEnumeration>(OtherSampleEnumeration.Six));
        }

        [Test]
        public void isFilled_works_on_filled_strings()
        {
            IValidator a;
            string sample;

            a = Asserts.Default;
            sample = "lorem ipsum";
            a.isFilled(sample);
        }

        [Test]
        public void exception_is_thrown_when_receive_empty_or_null_string()
        {
            IValidator a;

            a = Asserts.Default;

            a.Invoking(ass => ass.isFilled(null))
                .Should()
                .ThrowExactly<NullOrEmptyStringAssertException>();

            a.Invoking(ass => ass.isFilled("   "))
                .Should()
                .ThrowExactly<NullOrEmptyStringAssertException>();
        }
    }
}