using Blacksmith.Validations.Exceptions;

namespace Blacksmith.Validations
{
    public class Asserts : AbstractValidator<AssertException>
    {
        static Asserts()
        {
            Assert = new Asserts(new EnValidatorStrings());
        }

        private Asserts(IValidatorStrings validatorStrings) : base(validatorStrings)
        {
        }

        public static Asserts Assert { get; }

        protected override AssertException prv_buildException(string message)
        {
            return new AssertException(message);
        }
    }
}