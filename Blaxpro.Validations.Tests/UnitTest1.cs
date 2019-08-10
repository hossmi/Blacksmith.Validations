using Blaxpro.Validations.Exceptions;
using Blaxpro.Validations.Tests.SampleDomain;
using NUnit.Framework;

namespace Blaxpro.Validations.Tests
{
    public class Tests
    {
        private readonly DefaultValidatorStrings validationStrings;

        public Tests()
        {
            this.validationStrings = new DefaultValidatorStrings();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Vehicle car;

            car = new Vehicle(this.validationStrings, "ABC1234");
            car.Plate = "XXX0000";

            try
            {
                car.Plate = "12345678901234567890123456789012345678901";
            }
            catch (BusinessException)
            {
            }
        }
    }
}