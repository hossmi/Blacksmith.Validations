
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Blaxpro.Validations.Exceptions;

namespace Blaxpro.Validations
{
    public abstract class AbstractValidator
    {
        private readonly IValidatorStrings strings;

        public AbstractValidator()
        {
            this.strings = new DefaultValidatorStrings();
        }

        public AbstractValidator(IValidatorStrings validatorStrings)
        {
            this.strings = validatorStrings ?? throw new ArgumentNullException(nameof(validatorStrings));
        }

        //protected  void prv_enumeration<T>(T value, string message = ""
        //    , [CallerLineNumber] int sourceLineNumber = 0
        //    , [CallerMemberName] string memberName = ""
        //    , [CallerFilePath] string sourceFilePath = "") where T : Enumeration
        //{
        //    if (string.IsNullOrWhiteSpace(message))
        //        message = $"Enumeration value is not a valid one of {typeof(T).FullName}.";

        //    prv_validate(value != null && Enumeration.isDefined(value), message, memberName, sourceFilePath, sourceLineNumber);
        //}

        protected void prv_isValidEnum<T>(T enumValue, string message = ""
            , [CallerLineNumber] int sourceLineNumber = 0
            , [CallerMemberName] string memberName = ""
            , [CallerFilePath] string sourceFilePath = "") where T : struct
        {
            if (string.IsNullOrWhiteSpace(message))
                message = string.Format(this.strings.ENUM_VALUE_IS_NOT_A_VALID_ONE_OF_TYPE_0, typeof(T).FullName);

            prv_validate(Enum.IsDefined(typeof(T), enumValue), message, memberName, sourceFilePath, sourceLineNumber);
        }

        protected void prv_fileExists(string filePath, string message = ""
            , [CallerLineNumber] int sourceLineNumber = 0
            , [CallerMemberName] string memberName = ""
            , [CallerFilePath] string sourceFilePath = "")
        {
            prv_stringIsNotEmpty(filePath, "", sourceLineNumber, memberName, sourceFilePath);

            if (string.IsNullOrWhiteSpace(message))
                message = string.Format(this.strings.REQUIRED_FILE_0_DOES_NOT_EXIST, filePath);

            prv_validate(File.Exists(filePath), message, memberName, sourceFilePath, sourceLineNumber);
        }

        protected void prv_fileNotExists(string filePath, string message = ""
            , [CallerLineNumber] int sourceLineNumber = 0
            , [CallerMemberName] string memberName = ""
            , [CallerFilePath] string sourceFilePath = "")
        {
            prv_stringIsNotEmpty(filePath, "", sourceLineNumber, memberName, sourceFilePath);

            if (string.IsNullOrWhiteSpace(message))
                message = string.Format(this.strings.FILE_0_CANNOT_EXIST, filePath);

            prv_validate(File.Exists(filePath) == false, message, memberName, sourceFilePath, sourceLineNumber);
        }

        protected void prv_stringLength(string item, int minLength, int maxLength, string message = ""
            , [CallerLineNumber] int sourceLineNumber = 0
            , [CallerMemberName] string memberName = ""
            , [CallerFilePath] string sourceFilePath = "")
        {
            prv_validate(0 < minLength, string.Format(this.strings.OUT_OF_RANGE_VALUE_FOR_0, nameof(minLength)), memberName, sourceFilePath, sourceLineNumber);
            prv_validate(0 < maxLength, string.Format(this.strings.OUT_OF_RANGE_VALUE_FOR_0, nameof(maxLength)), memberName, sourceFilePath, sourceLineNumber);
            prv_validate(minLength <= maxLength, string.Format(this.strings.PARAMETER_0_MUST_BE_LESS_OR_EQUAL_THAN_PARAMETER_1, nameof(minLength), nameof(maxLength)), memberName, sourceFilePath, sourceLineNumber);
            prv_stringIsNotEmpty(item, "", sourceLineNumber, memberName, sourceFilePath);

            if (string.IsNullOrWhiteSpace(message))
                message = $"Text length must be between {minLength} and {maxLength}.";

            prv_validate(minLength <= item.Length && item.Length <= maxLength, message, memberName, sourceFilePath, sourceLineNumber);
        }

        protected void prv_stringMinLength(string item, int minLength, string message = ""
            , [CallerLineNumber] int sourceLineNumber = 0
            , [CallerMemberName] string memberName = ""
            , [CallerFilePath] string sourceFilePath = "")
        {
            prv_validate(0 < minLength, string.Format(this.strings.OUT_OF_RANGE_VALUE_FOR_0, nameof(minLength)), memberName, sourceFilePath, sourceLineNumber);
            prv_stringIsNotEmpty(item, "", sourceLineNumber, memberName, sourceFilePath);

            if (string.IsNullOrWhiteSpace(message))
                message = $"Text length must be greater or equal than {minLength}.";

            prv_validate(minLength <= item.Length, message, memberName, sourceFilePath, sourceLineNumber);
        }

        protected void prv_stringMaxLength(string item, int maxLength, string message = ""
            , [CallerLineNumber] int sourceLineNumber = 0
            , [CallerMemberName] string memberName = ""
            , [CallerFilePath] string sourceFilePath = "")
        {
            prv_validate(0 < maxLength, string.Format(this.strings.OUT_OF_RANGE_VALUE_FOR_0, nameof(maxLength)), memberName, sourceFilePath, sourceLineNumber);
            prv_stringIsNotEmpty(item, "", sourceLineNumber, memberName, sourceFilePath);

            if (string.IsNullOrWhiteSpace(message))
                message = $"Text length must be less or equal than {maxLength}.";

            prv_validate(item.Length <= maxLength, message, memberName, sourceFilePath, sourceLineNumber);
        }

        protected void prv_stringMatchRegex(string someString, Regex regex, string message = ""
            , [CallerLineNumber] int sourceLineNumber = 0
            , [CallerMemberName] string memberName = ""
            , [CallerFilePath] string sourceFilePath = "")
        {
            prv_stringIsNotEmpty(someString, "", sourceLineNumber, memberName, sourceFilePath);
            prv_validate(regex != null, this.strings.ITEM_CANNOT_BE_NULL, memberName, sourceFilePath, sourceLineNumber);

            if (string.IsNullOrWhiteSpace(message))
                message = this.strings.TEXT_DOES_NOT_MATCH_REGULAR_EXPRESSION;
            prv_validate(regex.IsMatch(someString), message, memberName, sourceFilePath, sourceLineNumber);
        }

        protected void prv_isTrue(bool condition, string message
            , [CallerLineNumber] int sourceLineNumber = 0
            , [CallerMemberName] string memberName = ""
            , [CallerFilePath] string sourceFilePath = "")
        {
            prv_validate(condition, message, memberName, sourceFilePath, sourceLineNumber);
        }

        protected void prv_isFalse(bool condition, string message
            , [CallerLineNumber] int sourceLineNumber = 0
            , [CallerMemberName] string memberName = ""
            , [CallerFilePath] string sourceFilePath = "")
        {
            prv_validate(condition == false, message, memberName, sourceFilePath, sourceLineNumber);
        }

        protected void prv_fail(string message
            , [CallerLineNumber] int sourceLineNumber = 0
            , [CallerMemberName] string memberName = ""
            , [CallerFilePath] string sourceFilePath = "")
        {
            throw new BusinessException(message, sourceLineNumber, memberName, sourceFilePath);
        }

        protected void prv_isNotNull<T>(T item, string message = ""
            , [CallerLineNumber] int sourceLineNumber = 0
            , [CallerMemberName] string memberName = ""
            , [CallerFilePath] string sourceFilePath = "") where T : class
        {
            if (string.IsNullOrWhiteSpace(message))
                message = this.strings.ITEM_CANNOT_BE_NULL;

            prv_validate(item != null, message, memberName, sourceFilePath, sourceLineNumber);
        }

        protected void prv_isNull<T>(T item, string message = ""
            , [CallerLineNumber] int sourceLineNumber = 0
            , [CallerMemberName] string memberName = ""
            , [CallerFilePath] string sourceFilePath = "") where T : class
        {
            if (string.IsNullOrWhiteSpace(message))
                message = "Item must be null.";

            prv_validate(item == null, message, memberName, sourceFilePath, sourceLineNumber);
        }

        protected void prv_isInstanceOf<T>(object item, string message = ""
            , [CallerLineNumber] int sourceLineNumber = 0
            , [CallerMemberName] string memberName = ""
            , [CallerFilePath] string sourceFilePath = "")
        {
            if (string.IsNullOrWhiteSpace(message))
                message = $"Item is not an instance of {typeof(T).FullName}";

            prv_validate(item is T, message, memberName, sourceFilePath, sourceLineNumber);
        }

        protected void prv_stringIsNotEmpty(string someString, string message = ""
            , [CallerLineNumber] int sourceLineNumber = 0
            , [CallerMemberName] string memberName = ""
            , [CallerFilePath] string sourceFilePath = "")
        {
            if (string.IsNullOrWhiteSpace(message))
                message = this.strings.STRING_CANNOT_BE_EMPTY;

            prv_validate(string.IsNullOrWhiteSpace(someString) == false, message, memberName, sourceFilePath, sourceLineNumber);
        }

        protected static void prv_validate(bool condition, string message, string memberName, string sourceFilePath, int sourceLineNumber)
        {
            if (condition == false)
                throw new BusinessException(message, sourceLineNumber, memberName, sourceFilePath);
        }
    }
}