using Blacksmith.Localized.Attributes;

namespace Blacksmith.Validations.Localizations
{
    [Culture("es-ES")]
    public class EsExceptionStrings : IExceptionStrings
    {
        public string String_cannot_be_empty => "El texto no puede estar vacío.";
        public string Item_cannot_be_null => "El elemento no puede ser nulo.";
        public string Out_of_Range_value_for_0 => "Valor fuera de rango para el parámetro {0}.";
        public string Parameter_0_must_be_less_or_equal_than_parameter_1 => "Parámetro '{0}' debe ser menor o igual al parámetro '{1}'.";
        public string Text_does_not_match_regular_expression => "El texto no casa con la expresión regular.";
        public string Enum_value_is_not_a_valid_one_of_type_0 => "No es un valor válido de enumerados '{0}'.";
        public string File_0_must_exist => "El fichero '{0}' debe existir.";
        public string File_0_cannot_exist => "El fichero '{0}' no debe existir.";
        public string Item_must_be_null => "El elemento debe ser nulo.";
        public string Item_is_not_an_instance_of_0 => "El elemento no es una instancia del {0}.";
        public string Text_length_must_be_between_0_and_1 => "La longitud del texto debe estar entre {0} and {1}.";
        public string Text_length_must_be_less_or_equal_than_0 => "La longitud del texto debe ser a lo sumo {0}.";
        public string Text_length_must_be_greater_or_equal_than_0 => "La longitud del texto debe ser al menos {0}.";
    }
}