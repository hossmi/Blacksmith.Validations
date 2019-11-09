using Blacksmith.Localized.Attributes;

namespace Blacksmith.Validations.Localizations
{
    [Culture("en-US")]
    public class EnExceptionStrings : IExceptionStrings
    {
        public string String_cannot_be_empty => "String cannot be empty.";
        public string Item_cannot_be_null => "Item cannot be null.";
        public string Out_of_Range_value_for_0 => "Invalid value for '{0}' parameter.";
        public string Parameter_0_must_be_less_or_equal_than_parameter_1 => "Parameter '{0}' must be less or equal than parameter '{1}'.";
        public string Text_does_not_match_regular_expression => "Text does not match regular expression.";
        public string Enum_value_is_not_a_valid_one_of_type_0 => "Enum value is not a valid one of {0}.";
        public string File_0_must_exist => "Required file '{0}' does not exist.";
        public string File_0_cannot_exist => "File '{0}' cannot exist.";
        public string Item_must_be_null => "Item must be null.";
        public string Item_is_not_an_instance_of_0 => "Item is not an instance of {0}.";
        public string Text_length_must_be_between_0_and_1 => "Text length must be between {0} and {1}.";
        public string Text_length_must_be_less_or_equal_than_0 => "Text length must be less or equal than {0}.";
        public string Text_length_must_be_greater_or_equal_than_0 => "Text length must be greater or equal than {0}.";
    }
}