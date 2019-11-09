using Blacksmith.Enumerations;

namespace Blacksmith.Validations
{
    public interface IValidator
    {
        void fail();
        void isTrue(bool condition);
        void isFalse(bool condition);

        void isInstanceOf<T>(object item);
        void isNotNull<T>(T item) where T : class;
        void isNull<T>(T item) where T : class;
        void isValidEnum<T>(T enumValue) where T : struct;
        void isValidEnumeration<T>(T value) where T : Enumeration;
    }
}