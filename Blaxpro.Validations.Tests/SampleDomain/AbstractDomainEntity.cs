using Blaxpro.Localized.Services;

namespace Blaxpro.Validations.Tests.SampleDomain
{
    public abstract class AbstractDomainEntity
    {
        protected readonly IDomainStrings strings;
        protected readonly DomainValidator validate;

        public AbstractDomainEntity()
        {
            this.strings = new LocalizationService().get<IDomainStrings>();
            this.validate = new DomainValidator(this.strings);
        }
    }
}
