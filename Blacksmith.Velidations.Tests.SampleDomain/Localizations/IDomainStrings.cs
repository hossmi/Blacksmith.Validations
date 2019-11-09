using Blacksmith.Validations.Localizations;

namespace Blacksmith.Velidations.Tests.SampleDomain.Localizations
{
    public interface IDomainStrings : IExceptionStrings
    {
        string Wheels_parameter_must_be_between_0_and_28 { get; }
        string Wheels_parameter_must_be_an_odd_number { get; }
    }
}