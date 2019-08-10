using Blaxpro.Validations.Exceptions;

namespace Blaxpro.Validations.Tests.SampleDomain
{
    public class DomainValidator : AbstractValidator<BusinessException>
    {
        private readonly IDomainStrings domainStrings;

        public DomainValidator(IDomainStrings domainStrings) : base(domainStrings, prv_newException)
        {
            this.domainStrings = domainStrings;
        }

        private static BusinessException prv_newException(string message, int sourceLineNumber, string memberName, string sourceFilePath)
        {
            return new BusinessException(message, sourceLineNumber, memberName, sourceFilePath);
        }

    }
}