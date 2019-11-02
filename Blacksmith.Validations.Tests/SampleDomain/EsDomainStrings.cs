using Blacksmith.Localized.Attributes;
using Blacksmith.Validations.Localizations;

namespace Blacksmith.Validations.Tests.SampleDomain
{
    [Culture("es-es")]
    public class EsDomainStrings : EsValidatorStrings, IDomainStrings
    {
        public string Wheels_parameter_must_be_between_0_and_28 => "El vehículo solo puede tener entre cero y veintiotro ruedas.";
        public string Wheels_parameter_must_be_an_odd_number => "El número de ruedas debe ser un número par.";
    }
}