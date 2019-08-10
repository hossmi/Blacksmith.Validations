using Blaxpro.Validations.Exceptions;

namespace Blaxpro.Validations
{
    public class Asserts : AbstractValidator<AssertException>
    {
        static Asserts()
        {
            Assert = new Asserts(new DefaultValidatorStrings());
        }

        private Asserts(IValidatorStrings validatorStrings) 
            : base(validatorStrings)
        {
        }

        public static Asserts Assert { get; }

        protected override AssertException prv_buildException(string message, int sourceLineNumber, string memberName, string sourceFilePath)
        {
            return new AssertException(message, sourceLineNumber, memberName, sourceFilePath);
        }
    }
}