using Blacksmith.Velidations.Tests.SampleDomain.Exceptions;

namespace Blacksmith.Validations.Tests.SampleDomain
{
    public class Vehicle : AbstractSampleDomain
    {

        private string plate;
        private int wheels;
        private string model;

        public Vehicle(string plate, int wheels, string model)
        {
            this.Plate = plate;
            this.Wheels = wheels;
            this.Model = model;
        }

        public string Plate
        {
            get => this.plate;
            set
            {
                plateIsValid(value);
                this.plate = value;
            }
        }

        public int Wheels
        {
            get => this.wheels;
            set
            {
                validateVehicleWheels(value);
                this.wheels = value;
            }
        }

        public string Model
        {
            get => this.model;
            set
            {
                stringIsNotEmpty<RequiredVehicleModelDomainException>(value);
                this.model = value;
            }
        }
    }
}