using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Blaxpro.Validations
{
    public interface IValidator<TException> where TException : Exception
    {
        void fail(string message = "", [CallerLineNumber] int sourceLineNumber = 0, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "");
        void fileExists(string filePath, string message = "", [CallerLineNumber] int sourceLineNumber = 0, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "");
        void fileNotExists(string filePath, string message = "", [CallerLineNumber] int sourceLineNumber = 0, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "");
        void isFalse(bool condition, string message = "", [CallerLineNumber] int sourceLineNumber = 0, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "");
        void isInstanceOf<T>(object item, string message = "", [CallerLineNumber] int sourceLineNumber = 0, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "");
        void isNotNull<T>(T item, string message = "", [CallerLineNumber] int sourceLineNumber = 0, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "") where T : class;
        void isNull<T>(T item, string message = "", [CallerLineNumber] int sourceLineNumber = 0, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "") where T : class;
        void isTrue(bool condition, string message, [CallerLineNumber] int sourceLineNumber = 0, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "");
        void isValidEnum<T>(T enumValue, string message = "", [CallerLineNumber] int sourceLineNumber = 0, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "") where T : struct;
        void stringIsNotEmpty(string someString, string message = "", [CallerLineNumber] int sourceLineNumber = 0, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "");
        void stringLength(string item, int minLength, int maxLength, string message = "", [CallerLineNumber] int sourceLineNumber = 0, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "");
        void stringMatchRegex(string someString, Regex regex, string message = "", [CallerLineNumber] int sourceLineNumber = 0, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "");
        void stringMaxLength(string item, int maxLength, string message = "", [CallerLineNumber] int sourceLineNumber = 0, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "");
        void stringMinLength(string item, int minLength, string message = "", [CallerLineNumber] int sourceLineNumber = 0, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "");
    }
}