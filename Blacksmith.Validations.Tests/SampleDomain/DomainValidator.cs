namespace Blacksmith.Validations.Tests.SampleDomain
{
    public class DomainValidator : AbstractDomainValidator
    {
        private readonly IDomainStrings domainStrings;

        public DomainValidator(IDomainStrings domainStrings) : base(domainStrings)
        {
            this.domainStrings = domainStrings;
        }
    }
}