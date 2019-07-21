namespace Blaxpro.Validations
{
    public class EnglishValidatorStrings : IValidatorStrings
    {
        public string STRING_CANNOT_BE_EMPTY => "String cannot be empty.";
        public string ITEM_CANNOT_BE_NULL => "Item cannot be null.";
        public string OUT_OF_RANGE_VALUE_FOR_0 => "Invalid value for {0} parameter";
        public string PARAMETER_0_MUST_BE_LESS_OR_EQUAL_THAN_PARAMETER_1 => "Parameter {0} must be less or equal than parameter {1}";
        public string TEXT_DOES_NOT_MATCH_REGULAR_EXPRESSION => "Text does not match regular expression";
        public string ENUM_VALUE_IS_NOT_A_VALID_ONE_OF_TYPE_0 => "Enum value is not a valid one of {0}.";
        public string REQUIRED_FILE_DOES_NOT_EXIST => "Required file '{0}' does not exist.";
        public string FILE_CANNOT_EXIST => "File '{0}' cannot exist.";
    }
}