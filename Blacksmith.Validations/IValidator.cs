using Blacksmith.Enumerations;

namespace Blacksmith.Validations
{
    public interface IValidator
    {
        void fail();
        void fail(string failreasonMessage);
        void isTrue(bool condition);
        void isTrue(bool condition, string failreasonMessage);
        void isFalse(bool condition);
        void isFalse(bool condition, string failreasonMessage);

        void isInstanceOf<T>(object item);
        void isNotNull<T>(T item) where T : class;
        void isNull<T>(T item) where T : class;
        void isValidEnum<T>(T enumValue) where T : struct;
        void isValidEnumeration<T>(T value) where T : Enumeration;
        void isFilled(string text);
    }
}