using Blaxpro.Validations;
using Blaxpro.Validations.Exceptions;
using NUnit.Framework;

namespace Tests
{
    public class SampleDomainClass : Validator
    {
        private string requiredField;

        public SampleDomainClass(string initialRequiredProperty)
        {
            this.RequiredProperty = initialRequiredProperty;
        }

        public string RequiredProperty
        {
            get => this.requiredField;
            set
            {
                this.stringMaxLength(value, 40);
                this.requiredField = value;
            }
        }
    }

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            SampleDomainClass sampleDomainClass;

            sampleDomainClass = new SampleDomainClass("it's ok");
            sampleDomainClass.RequiredProperty = "1234567890123456789012345678901234567890";

            try
            {
                sampleDomainClass.RequiredProperty = "12345678901234567890123456789012345678901";
            }
            catch (BusinessException)
            {
            }
        }
    }
}