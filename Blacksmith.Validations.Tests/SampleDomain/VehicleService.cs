using Blacksmith.Validations.Exceptions;
using System.Text.RegularExpressions;

namespace Blacksmith.Validations.Tests.SampleDomain
{
    public class VehicleService : IVehicleService
    {
        private readonly IValidator validate;
        private readonly IDomainStrings domainStrings;

        public VehicleService(IDomainStrings strings)
        {
            this.validate = new Validator<DomainException>(strings, prv_buildException);
            this.domainStrings = strings;
        }

        private static DomainException prv_buildException(string message)
        {
            return new DomainException(message);
        }

        public IVehicle createVehicle(string plate)
        {
            return new PrvVehicle(this.validate, this.domainStrings, plate);
        }

        private class PrvVehicle : IVehicle
        {
            private static readonly Regex plateRegex = new Regex(@"[A-Z]{3}[0-9]{4}"
                , RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.Singleline);
            
            private readonly IValidator validate;
            private readonly IDomainStrings strings;
            private string plate;
            private int wheels;

            public PrvVehicle(IValidator validate, IDomainStrings strings, string plate) 
            {
                this.validate = validate;
                this.strings = strings;
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
}