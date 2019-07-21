using Blaxpro.Validations;
using Blaxpro.Validations.Exceptions;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        private readonly EnglishValidatorStrings validationStrings;

        public Tests()
        {
            this.validationStrings = new EnglishValidatorStrings();
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