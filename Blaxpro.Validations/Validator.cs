
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Blaxpro.Validations.Exceptions;

namespace Blaxpro.Validations
{
    public class Validator
    {
        private const string STRING_CANNOT_BE_EMPTY = "String cannot be empty.";
        private const string ITEM_CANNOT_BE_NULL = "Item cannot be null.";
        private const string INVALID_0_VALUE = "Invalid value for {0} parameter";
        private const string PARAMETER_0_MUST_BE_LESS_OR_EQUAL_THAN_1 = "Parameter {0} must be less or equal than parameter {1}";

        //protected virtual void enumeration<T>(T value, string message = ""
        //    , [CallerLineNumber] int sourceLineNumber = 0
        //    , [CallerMemberName] string memberName = ""
        //    , [CallerFilePath] string sourceFilePath = "") where T : Enumeration
        //{
        //    if (string.IsNullOrWhiteSpace(message))
        //        message = $"Enumeration value is not a valid one of {typeof(T).FullName}.";

        //    prv_validate(value != null && Enumeration.isDefined(value), message, memberName, sourceFilePath, sourceLineNumber);
        //}

        protected virtual void isValidEnum<T>(T enumValue, string  message = ""
            , [CallerLineNumber] int sourceLineNumber = 0
            , [CallerMemberName] string memberName = ""
            , [CallerFilePath] string sourceFilePath = "") where T : struct
        {
            if (string.IsNullOrWhiteSpace(message))
                message = $"Enum value is not a valid one of {typeof(T).FullName}.";

            prv_validate(Enum.IsDefined(typeof(T), enumValue), message, memberName, sourceFilePath, sourceLineNumber);
        }

        protected virtual void fileExists(string filePath, string message = ""
            , [CallerLineNumber] int sourceLineNumber = 0
            , [CallerMemberName] string memberName = ""
            , [CallerFilePath] string sourceFilePath = "")
        {
            prv_stringIsNotEmpty(filePath, "", memberName, sourceFilePath, sourceLineNumber);

            if (string.IsNullOrWhiteSpace(message))
                message = $"Required file '{filePath}' does not exist.";

            prv_validate(File.Exists(filePath), message, memberName, sourceFilePath, sourceLineNumber);
        }

        protected virtual void fileNotExists(string filePath, string message = ""
            , [CallerLineNumber] int sourceLineNumber = 0
            , [CallerMemberName] string memberName = ""
            , [CallerFilePath] string sourceFilePath = "")
        {
            prv_stringIsNotEmpty(filePath, "", memberName, sourceFilePath, sourceLineNumber);

            if (string.IsNullOrWhiteSpace(message))
                message = $"File '{filePath}' cannot exist.";

            prv_validate(File.Exists(filePath) == false, message, memberName, sourceFilePath, sourceLineNumber);
        }

        protected virtual void stringLength(string item, int minLength, int maxLength, string message = ""
            , [CallerLineNumber] int sourceLineNumber = 0
            , [CallerMemberName] string memberName = ""
            , [CallerFilePath] string sourceFilePath = "")
        {
            prv_validate(0 < minLength, string.Format(INVALID_0_VALUE, nameof(minLength)), memberName, sourceFilePath, sourceLineNumber);
            prv_validate(0 < maxLength, string.Format(INVALID_0_VALUE, nameof(maxLength)), memberName, sourceFilePath, sourceLineNumber);
            prv_validate(minLength <= maxLength, string.Format(PARAMETER_0_MUST_BE_LESS_OR_EQUAL_THAN_1, nameof(minLength), nameof(maxLength)), memberName, sourceFilePath, sourceLineNumber);
            prv_stringIsNotEmpty(item, "", memberName, sourceFilePath, sourceLineNumber);

            if (string.IsNullOrWhiteSpace(message))
                message = $"Text length must be between {minLength} and {maxLength}.";

            prv_validate(minLength <= item.Length && item.Length <= maxLength, message, memberName, sourceFilePath, sourceLineNumber);
        }

        protected virtual void stringMinLength(string item, int minLength, string message = ""
            , [CallerLineNumber] int sourceLineNumber = 0
            , [CallerMemberName] string memberName = ""
            , [CallerFilePath] string sourceFilePath = "")
        {
            prv_validate(0 < minLength, string.Format(INVALID_0_VALUE,nameof(minLength)), memberName, sourceFilePath, sourceLineNumber);
            prv_stringIsNotEmpty(item, "", memberName, sourceFilePath, sourceLineNumber);

            if (string.IsNullOrWhiteSpace(message))
                message = $"Text length must be greater or equal than {minLength}.";

            prv_validate(minLength <= item.Length, message, memberName, sourceFilePath, sourceLineNumber);
        }

        protected virtual void stringMaxLength(string item, int maxLength, string message = ""
            , [CallerLineNumber] int sourceLineNumber = 0
            , [CallerMemberName] string memberName = ""
            , [CallerFilePath] string sourceFilePath = "")
        {
            prv_validate(0 < maxLength, string.Format(INVALID_0_VALUE, nameof(maxLength)), memberName, sourceFilePath, sourceLineNumber);
            prv_stringIsNotEmpty(item, "", memberName, sourceFilePath, sourceLineNumber);

            if (string.IsNullOrWhiteSpace(message))
                message = $"Text length must be less or equal than {maxLength}.";

            prv_validate(item.Length <= maxLength, message, memberName, sourceFilePath, sourceLineNumber);
        }

        protected virtual void stringMatchRegex(string someString, Regex regex, string message = ""
            , [CallerLineNumber] int sourceLineNumber = 0
            , [CallerMemberName] string memberName = ""
            , [CallerFilePath] string sourceFilePath = "")
        {
            prv_stringIsNotEmpty(someString, "", memberName, sourceFilePath, sourceLineNumber);
            prv_validate(regex != null, ITEM_CANNOT_BE_NULL, memberName, sourceFilePath, sourceLineNumber);

            if (string.IsNullOrWhiteSpace(message))
                message = "Text does not match regular expression";
            prv_validate(regex.IsMatch(someString), message, memberName, sourceFilePath, sourceLineNumber);
        }

        protected virtual void stringIsNotEmpty(string someString, string message = ""
            , [CallerLineNumber] int sourceLineNumber = 0
            , [CallerMemberName] string memberName = ""
            , [CallerFilePath] string sourceFilePath = "")
        {
            prv_stringIsNotEmpty(someString, message, memberName, sourceFilePath, sourceLineNumber);
        }

        protected virtual void isTrue(bool condition, string message
            , [CallerLineNumber] int sourceLineNumber = 0
            , [CallerMemberName] string memberName = ""
            , [CallerFilePath] string sourceFilePath = "")
        {
            prv_validate(condition, message, memberName, sourceFilePath, sourceLineNumber);
        }

        protected virtual void isFalse(bool condition, string message
            , [CallerLineNumber] int sourceLineNumber = 0
            , [CallerMemberName] string memberName = ""
            , [CallerFilePath] string sourceFilePath = "")
        {
            prv_validate(condition == false, message, memberName, sourceFilePath, sourceLineNumber);
        }

        protected virtual void fail(string message
            , [CallerLineNumber] int sourceLineNumber = 0
            , [CallerMemberName] string memberName = ""
            , [CallerFilePath] string sourceFilePath = "")
        {
            throw new BusinessException(message, sourceLineNumber, memberName, sourceFilePath);
        }

        protected virtual void isNotNull<T>(T item, string message = ""
            , [CallerLineNumber] int sourceLineNumber = 0
            , [CallerMemberName] string memberName = ""
            , [CallerFilePath] string sourceFilePath = "") where T : class
        {
            if (string.IsNullOrWhiteSpace(message))
                message = ITEM_CANNOT_BE_NULL;

            prv_validate(item != null, message, memberName, sourceFilePath, sourceLineNumber);
        }

        protected virtual void isNull<T>(T item, string message = ""
            , [CallerLineNumber] int sourceLineNumber = 0
            , [CallerMemberName] string memberName = ""
            , [CallerFilePath] string sourceFilePath = "") where T : class
        {
            if (string.IsNullOrWhiteSpace(message))
                message = "Item must be null.";

            prv_validate(item == null, message, memberName, sourceFilePath, sourceLineNumber);
        }

        protected virtual void isInstanceOf<T>(object item, string message = ""
            , [CallerLineNumber] int sourceLineNumber = 0
            , [CallerMemberName] string memberName = ""
            , [CallerFilePath] string sourceFilePath = "")
        {
            if (string.IsNullOrWhiteSpace(message))
                message = $"Item is not an instance of {typeof(T).FullName}";

            prv_validate(item is T, message, memberName, sourceFilePath, sourceLineNumber);
        }

        protected static void prv_stringIsNotEmpty(string someString, string message, string memberName, string sourceFilePath, int sourceLineNumber)
        {
            if (string.IsNullOrWhiteSpace(message))
                message = STRING_CANNOT_BE_EMPTY;

            prv_validate(string.IsNullOrWhiteSpace(someString) == false, message, memberName, sourceFilePath, sourceLineNumber);
        }

        protected static void prv_validate(bool condition, string message, string memberName, string sourceFilePath, int sourceLineNumber)
        {
            if (condition == false)
                throw new BusinessException(message, sourceLineNumber, memberName, sourceFilePath);
        }
    }
}