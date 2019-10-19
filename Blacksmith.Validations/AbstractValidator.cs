using System;
using System.IO;
using System.Text.RegularExpressions;
using Blacksmith.Enumerations;

namespace Blacksmith.Validations
{
    public abstract class AbstractValidator<TException> : IValidator where TException : Exception
    {
        private readonly IValidatorStrings strings;

        public AbstractValidator(IValidatorStrings validatorStrings)
        {
            this.strings = validatorStrings ?? throw new ArgumentNullException(nameof(validatorStrings));
        }

        public void fail(string message)
        {
            stringIsNotEmpty(message);
            throw prv_buildException(message);
        }

        public void fileExists(string filePath, string message = null)
        {
            stringIsNotEmpty(filePath);
            prv_validate(File.Exists(filePath)
                , message ?? string.Format(this.strings.File_0_must_exist, filePath));
        }

        public void fileNotExists(string filePath, string message = null)
        {
            stringIsNotEmpty(filePath);
            prv_validate(File.Exists(filePath) == false
                , message ?? string.Format(this.strings.File_0_cannot_exist, filePath));
        }

        public void isFalse(bool condition, string message)
        {
            stringIsNotEmpty(message);
            prv_validate(condition == false, message);
        }

        public void isInstanceOf<T>(object item, string message = null)
        {
            prv_validate(item is T
                , message ?? string.Format(this.strings.Item_is_not_an_instance_of_0, typeof(T).FullName));
        }

        public void isNotNull<T>(T item, string message = null) where T : class
        {
            prv_validate(item != null
                , message ?? this.strings.Item_cannot_be_null);
        }

        public void isNull<T>(T item, string message = null) where T : class
        {
            prv_validate(item == null
                , message ?? this.strings.Item_must_be_null);
        }

        public void isTrue(bool condition, string message)
        {
            stringIsNotEmpty(message);
            prv_validate(condition, message);
        }

        public void isValidEnum<T>(T enumValue, string message = null) where T : struct
        {
            prv_validate(Enum.IsDefined(typeof(T), enumValue)
                , message ?? string.Format(this.strings.Enum_value_is_not_a_valid_one_of_type_0, typeof(T).FullName));
        }

        public void stringIsNotEmpty(string someString, string message = null)
        {
            prv_validate(string.IsNullOrWhiteSpace(someString) == false
                , message ?? this.strings.String_cannot_be_empty);
        }

        public void stringLength(string item, int minLength, int maxLength, string message = null)
        {
            stringIsNotEmpty(item);
            isTrue(0 < minLength, string.Format(this.strings.Out_of_Range_value_for_0, nameof(minLength)));
            isTrue(0 < maxLength, string.Format(this.strings.Out_of_Range_value_for_0, nameof(maxLength)));
            isTrue(minLength <= maxLength
                , string.Format(this.strings.Parameter_0_must_be_less_or_equal_than_parameter_1, nameof(minLength), nameof(maxLength)));

            prv_validate(minLength <= item.Length && item.Length <= maxLength
                , message ?? string.Format(this.strings.Text_length_must_be_between_0_and_1, minLength, maxLength));
        }

        public void stringMatchRegex(string someString, Regex regex, string message = null)
        {
            stringIsNotEmpty(someString);
            isNotNull(regex);
            prv_validate(regex.IsMatch(someString)
                , message ?? this.strings.Text_does_not_match_regular_expression);
        }

        public void stringMaxLength(string item, int maxLength, string message = null)
        {
            stringIsNotEmpty(item);
            isTrue(0 < maxLength, string.Format(this.strings.Out_of_Range_value_for_0, nameof(maxLength)));
            prv_validate(item.Length <= maxLength
                , message ?? string.Format(this.strings.Text_length_must_be_less_or_equal_than_0, maxLength));
        }

        public void stringMinLength(string item, int minLength, string message = null)
        {
            stringIsNotEmpty(item);
            isTrue(0 < minLength, string.Format(this.strings.Out_of_Range_value_for_0, nameof(minLength)));
            prv_validate(minLength <= item.Length
                , message ?? string.Format(this.strings.Text_length_must_be_greater_or_equal_than_0, minLength));
        }

        public void isValidEnumeration<T>(T value, string message = null) where T : Enumeration
        {
            prv_validate(value != null && Enumeration.isDefined(value)
                , message ?? string.Format(this.strings.Enum_value_is_not_a_valid_one_of_type_0, typeof(T).FullName));
        }

        private void prv_validate(bool condition, string errorMessage)
        {
            if (condition == false)
                throw prv_buildException(errorMessage);
        }

        protected abstract TException prv_buildException(string message);
    }
}