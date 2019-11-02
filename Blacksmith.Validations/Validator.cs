using Blacksmith.Validations.Localizations;
using System;

namespace Blacksmith.Validations
{
    public class Validator<TException> : AbstractValidator<TException> where TException : Exception
    {
        private readonly Func<string, TException> buildExceptionDelegate;

        public Validator(IValidatorStrings validatorStrings, Func<string, TException> buildExceptionDelegate) : base(validatorStrings)
        {
            this.buildExceptionDelegate = buildExceptionDelegate ?? throw new ArgumentNullException(nameof(buildExceptionDelegate));
        }

        protected override TException prv_buildException(string message)
        {
            return this.buildExceptionDelegate(message);
        }
    }
}