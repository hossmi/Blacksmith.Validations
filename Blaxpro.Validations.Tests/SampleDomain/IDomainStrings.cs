namespace Blaxpro.Validations.Tests.SampleDomain
{
    public interface IDomainStrings : IValidatorStrings
    {
        string Wheels_parameter_must_be_between_0_and_28 { get; }
        string Wheels_parameter_must_be_an_odd_number { get; }
    }
}