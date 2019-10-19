using System.Text.RegularExpressions;

namespace Blacksmith.Validations.Tests.SampleDomain
{
    public class Vehicle : AbstractDomainEntity
    {
        private static readonly Regex plateRegex = new Regex(@"[A-Z]{3}[0-9]{4}", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.Singleline);

        private string plate;
        private int wheels;

        public Vehicle(string plate) : base()
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
                this.validate.isTrue(0 < value && value <= 28, this.strings.Wheels_parameter_must_be_between_0_and_28);
                this.validate.isTrue(value % 2 == 0, this.strings.Wheels_parameter_must_be_an_odd_number);

                this.wheels = value;
            }
        }
    }
}