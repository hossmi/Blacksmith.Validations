
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Blaxpro.Validations.Exceptions;

namespace Blaxpro.Validations
{

    public abstract class AbstractValidator<TEx> : IValidator<TEx> where TEx : Exception
    {
        private readonly IValidatorStrings strings;

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

        public void isValidEnum<T>(T enumValue, string message = ""
            , [CallerLineNumber] int sourceLineNumber = 0
            , [CallerMemberName] string memberName = ""
            , [CallerFilePath] string sourceFilePath = "") where T : struct
        {
            prv_validate(Enum.IsDefined(typeof(T), enumValue)
                , message, memberName, sourceFilePath, sourceLineNumber
                , () => string.Format(this.strings.ENUM_VALUE_IS_NOT_A_VALID_ONE_OF_TYPE_0, typeof(T).FullName));
        }

        public void fileExists(string filePath, string message = ""
            , [CallerLineNumber] int sourceLineNumber = 0
            , [CallerMemberName] string memberName = ""
            , [CallerFilePath] string sourceFilePath = "")
        {
            stringIsNotEmpty(filePath, this.strings.STRING_CANNOT_BE_EMPTY, sourceLineNumber, memberName, sourceFilePath);

            prv_validate(File.Exists(filePath)
                , message, memberName, sourceFilePath, sourceLineNumber
                , () => string.Format(this.strings.REQUIRED_FILE_0_DOES_NOT_EXIST, filePath));
        }

        public void fileNotExists(string filePath, string message = ""
            , [CallerLineNumber] int sourceLineNumber = 0
            , [CallerMemberName] string memberName = ""
            , [CallerFilePath] string sourceFilePath = "")
        {
            stringIsNotEmpty(filePath, this.strings.STRING_CANNOT_BE_EMPTY, sourceLineNumber, memberName, sourceFilePath);

            prv_validate(File.Exists(filePath) == false
                , message, memberName, sourceFilePath, sourceLineNumber
                , () => string.Format(this.strings.FILE_0_CANNOT_EXIST, filePath));
        }

        public void stringLength(string item, int minLength, int maxLength, string message = ""
            , [CallerLineNumber] int sourceLineNumber = 0
            , [CallerMemberName] string memberName = ""
            , [CallerFilePath] string sourceFilePath = "")
        {
            isTrue(0 < minLength
                , string.Format(this.strings.OUT_OF_RANGE_VALUE_FOR_0, nameof(minLength))
                , sourceLineNumber, memberName, sourceFilePath);

            isTrue(0 < maxLength
                , string.Format(this.strings.OUT_OF_RANGE_VALUE_FOR_0, nameof(maxLength))
                , sourceLineNumber, memberName, sourceFilePath);

            isTrue(minLength <= maxLength
                , string.Format(this.strings.PARAMETER_0_MUST_BE_LESS_OR_EQUAL_THAN_PARAMETER_1, nameof(minLength), nameof(maxLength))
                , sourceLineNumber, memberName, sourceFilePath);

            stringIsNotEmpty(item, this.strings.STRING_CANNOT_BE_EMPTY, sourceLineNumber, memberName, sourceFilePath);

            prv_validate(minLength <= item.Length && item.Length <= maxLength
                , message, memberName, sourceFilePath, sourceLineNumber
                , () => $"Text length must be between {minLength} and {maxLength}.");
        }

        public void stringMinLength(string item, int minLength, string message = ""
            , [CallerLineNumber] int sourceLineNumber = 0
            , [CallerMemberName] string memberName = ""
            , [CallerFilePath] string sourceFilePath = "")
        {
            stringIsNotEmpty(item, this.strings.STRING_CANNOT_BE_EMPTY, sourceLineNumber, memberName, sourceFilePath);

            isTrue(0 < minLength
                , string.Format(this.strings.OUT_OF_RANGE_VALUE_FOR_0, nameof(minLength))
                , sourceLineNumber, memberName, sourceFilePath);

            prv_validate(minLength <= item.Length
                , message, memberName, sourceFilePath, sourceLineNumber
                , () => $"Text length must be greater or equal than {minLength}.");
        }

        public void stringMaxLength(string item, int maxLength, string message = ""
            , [CallerLineNumber] int sourceLineNumber = 0
            , [CallerMemberName] string memberName = ""
            , [CallerFilePath] string sourceFilePath = "")
        {
            stringIsNotEmpty(item, this.strings.STRING_CANNOT_BE_EMPTY, sourceLineNumber, memberName, sourceFilePath);

            isTrue(0 < maxLength
                , string.Format(this.strings.OUT_OF_RANGE_VALUE_FOR_0, nameof(maxLength))
                , sourceLineNumber, memberName, sourceFilePath);

            prv_validate(item.Length <= maxLength
                , message, memberName, sourceFilePath, sourceLineNumber
                , () => $"Text length must be less or equal than {maxLength}.");
        }

        public void stringMatchRegex(string someString, Regex regex, string message = ""
            , [CallerLineNumber] int sourceLineNumber = 0
            , [CallerMemberName] string memberName = ""
            , [CallerFilePath] string sourceFilePath = "")
        {
            stringIsNotEmpty(someString, this.strings.STRING_CANNOT_BE_EMPTY, sourceLineNumber, memberName, sourceFilePath);
            isNotNull(regex, this.strings.ITEM_CANNOT_BE_NULL, sourceLineNumber, memberName, sourceFilePath);

            prv_validate(regex.IsMatch(someString)
                , message, memberName, sourceFilePath, sourceLineNumber
                , () => this.strings.TEXT_DOES_NOT_MATCH_REGULAR_EXPRESSION);
        }

        public void isTrue(bool condition, string message = ""
            , [CallerLineNumber] int sourceLineNumber = 0
            , [CallerMemberName] string memberName = ""
            , [CallerFilePath] string sourceFilePath = "")
        {
            prv_validate(condition
                , message, memberName, sourceFilePath, sourceLineNumber
                , () => this.strings.EXPECTED_TRUE_CONDITION);
        }

        public void isFalse(bool condition, string message = ""
            , [CallerLineNumber] int sourceLineNumber = 0
            , [CallerMemberName] string memberName = ""
            , [CallerFilePath] string sourceFilePath = "")
        {
            prv_validate(condition == false
                , message, memberName, sourceFilePath, sourceLineNumber
                , () => this.strings.EXPECTED_FALSE_CONDITION);
        }

        public void fail(string message
            , [CallerLineNumber] int sourceLineNumber = 0
            , [CallerMemberName] string memberName = ""
            , [CallerFilePath] string sourceFilePath = "")
        {
            prv_validate(false
                , message, memberName, sourceFilePath, sourceLineNumber
                , () => this.strings.FAIL);
        }

        public void isNotNull<T>(T item, string message = ""
            , [CallerLineNumber] int sourceLineNumber = 0
            , [CallerMemberName] string memberName = ""
            , [CallerFilePath] string sourceFilePath = "") where T : class
        {
            prv_validate(item != null
                , message, memberName, sourceFilePath, sourceLineNumber
                , () => this.strings.ITEM_CANNOT_BE_NULL);
        }

        public void isNull<T>(T item, string message = ""
            , [CallerLineNumber] int sourceLineNumber = 0
            , [CallerMemberName] string memberName = ""
            , [CallerFilePath] string sourceFilePath = "") where T : class
        {
            prv_validate(item == null
                , message, memberName, sourceFilePath, sourceLineNumber
                , () => "Item must be null.");
        }

        public void isInstanceOf<T>(object item, string message = ""
            , [CallerLineNumber] int sourceLineNumber = 0
            , [CallerMemberName] string memberName = ""
            , [CallerFilePath] string sourceFilePath = "")
        {
            prv_validate(item is T
                , message, memberName, sourceFilePath, sourceLineNumber
                , () => $"Item is not an instance of {typeof(T).FullName}");
        }

        public void stringIsNotEmpty(string someString, string message = ""
            , [CallerLineNumber] int sourceLineNumber = 0
            , [CallerMemberName] string memberName = ""
            , [CallerFilePath] string sourceFilePath = "")
        {
            prv_validate(string.IsNullOrWhiteSpace(someString) == false
                , message, memberName, sourceFilePath, sourceLineNumber
                , () => this.strings.STRING_CANNOT_BE_EMPTY);
        }

        private void prv_validate(bool condition, string message, string memberName, string sourceFilePath, int sourceLineNumber, Func<string> buildDefaultMessage)
        {
            if (condition == false)
            {
                if (string.IsNullOrWhiteSpace(message))
                    message = buildDefaultMessage();

                throw prv_buildException(message, sourceLineNumber, memberName, sourceFilePath);
            }
        }

        protected abstract TEx prv_buildException(string message, int sourceLineNumber, string memberName, string sourceFilePath);
    }
}