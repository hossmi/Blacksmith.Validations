namespace Blaxpro.Validations
{
    public interface IValidatorStrings
    {
        string STRING_CANNOT_BE_EMPTY { get; }
        string ITEM_CANNOT_BE_NULL { get; }
        string OUT_OF_RANGE_VALUE_FOR_0 { get; }
        string PARAMETER_0_MUST_BE_LESS_OR_EQUAL_THAN_PARAMETER_1 { get; }
        string TEXT_DOES_NOT_MATCH_REGULAR_EXPRESSION { get; }
        string ENUM_VALUE_IS_NOT_A_VALID_ONE_OF_TYPE_0 { get; }
        string REQUIRED_FILE_0_DOES_NOT_EXIST { get; }
        string FILE_0_CANNOT_EXIST { get; }
        string FAIL { get; }
        string EXPECTED_FALSE_CONDITION { get; }
        string EXPECTED_TRUE_CONDITION { get; }
    }
}