using System;
using System.Collections.Generic;
using System.Text;
using Blaxpro.Validations.Exceptions;

namespace Blaxpro.Validations.Tests.SampleDomain
{
    public abstract class AbstractDomainEntity
    {
        protected readonly DomainValidator validate;

        public AbstractDomainEntity(IDomainStrings domainStrings)
        {
            this.validate = new DomainValidator(domainStrings);
        }
    }
}
