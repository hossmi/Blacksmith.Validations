using System.Text.RegularExpressions;

namespace Blaxpro.Validations.Tests.SampleDomain
{
    public class Vehicle : AbstractDomainEntity
    {
        private static readonly Regex plateRegex = new Regex(@"[A-Z]{3}[0-9]{4}", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.Singleline);

        private string plate;
        private int wheels;

        public Vehicle(IDomainStrings domainStrings, string plate) : base(domainStrings)
        {
            this.Plate = plate;
        }

        public string Plate
        {
            get => this.plate;
            set
            {
                this.validate.stringMatchRegex(value, plateRegex);
                this.validate.stringMaxLength(value, 10);
                this.plate = value;
            }
        }
        public int Wheels
        {
            get => this.wheels;
            set
            {
                this.validate.isTrue(0 < value && value <= 28, "Wheels parameter must be between 0 and 28.");
                this.validate.isTrue(value % 2 == 0, "Wheels parameter must be an odd number.");

                this.wheels = value;
            }
        }
    }
}