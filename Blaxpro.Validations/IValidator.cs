using System.Text.RegularExpressions;

namespace Blaxpro.Validations
{
    public interface IValidator
    {
        void fail(string message);
        void isTrue(bool condition, string message);
        void isFalse(bool condition, string message);
        void fileExists(string filePath, string message = null);
        void fileNotExists(string filePath, string message = null);
        void isInstanceOf<T>(object item, string message = null);
        void isNotNull<T>(T item, string message = null) where T : class;
        void isNull<T>(T item, string message = null) where T : class;
        void isValidEnum<T>(T enumValue, string message = null) where T : struct;
        void stringIsNotEmpty(string someString, string message = null);
        void stringLength(string item, int minLength, int maxLength, string message = null);
        void stringMatchRegex(string someString, Regex regex, string message = null);
        void stringMaxLength(string item, int maxLength, string message = null);
        void stringMinLength(string item, int minLength, string message = null);
    }
}