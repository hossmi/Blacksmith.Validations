using System.Text.RegularExpressions;

namespace Blaxpro.Validations
{
    public interface IValidator
    {
        void fail(string message);
        void isTrue(bool condition, string message);
        void isFalse(bool condition, string message);
        void fileExists(string filePath);
        void fileNotExists(string filePath);
        void isInstanceOf<T>(object item);
        void isNotNull<T>(T item) where T : class;
        void isNull<T>(T item) where T : class;
        void isValidEnum<T>(T enumValue) where T : struct;
        void stringIsNotEmpty(string someString);
        void stringLength(string item, int minLength, int maxLength);
        void stringMatchRegex(string someString, Regex regex);
        void stringMaxLength(string item, int maxLength);
        void stringMinLength(string item, int minLength);
    }
}