using System;
using System.Collections.Generic;
using System.Text;
using Blaxpro.Validations.Exceptions;

namespace Blaxpro.Validations
{
    public abstract class AbstractDomainValidator : AbstractValidator<DomainException>
    {
        public AbstractDomainValidator(IValidatorStrings validatorStrings) : base(validatorStrings)
        {
        }

        protected override DomainException prv_buildException(string message)
        {
            return new DomainException(message);
        }
    }
}
