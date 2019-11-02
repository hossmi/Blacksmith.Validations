using System;

namespace Blacksmith.Validations.Localizations
{
    public interface IValidatorStrings
    {
        string String_cannot_be_empty { get; }
        string Item_cannot_be_null { get; }
        string Item_must_be_null { get; }
        string Out_of_Range_value_for_0 { get; }
        string Parameter_0_must_be_less_or_equal_than_parameter_1 { get; }
        string Text_does_not_match_regular_expression { get; }
        string Enum_value_is_not_a_valid_one_of_type_0 { get; }
        string File_0_must_exist { get; }
        string File_0_cannot_exist { get; }
        string Item_is_not_an_instance_of_0 { get; }
        string Text_length_must_be_between_0_and_1 { get; }
        string Text_length_must_be_less_or_equal_than_0 { get; }
        string Text_length_must_be_greater_or_equal_than_0 { get; }
    }
}