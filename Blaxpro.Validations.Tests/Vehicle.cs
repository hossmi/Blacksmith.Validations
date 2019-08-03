using System.Text.RegularExpressions;

namespace Blaxpro.Validations.Tests
{
    public class Vehicle : AbstractValidator
    {
        private static readonly Regex plateRegex = new Regex(@"[A-Z]{3}[0-9]{4}", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.Singleline);

        private string plate;
        private int wheels;

        public Vehicle(IValidatorStrings validatorStrings, string plate) : base(validatorStrings)
        {
            this.Plate = plate;
        }

        public string Plate
        {
            get => this.plate;
            set
            {
                this.prv_stringMatchRegex(value, plateRegex);
                this.prv_stringMaxLength(value, 10);
                this.plate = value;
            }
        }
        public int Wheels
        {
            get => this.wheels;
            set
            {
                this.prv_isTrue(0 < value && value <= 28, "Wheels parameter must be between 0 and 28.");
                this.prv_isTrue(value % 2 == 0, "Wheels parameter must be an odd number.");

                this.wheels = value;
            }
        }
    }
}