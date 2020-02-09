using Blacksmith.Enumerations;
using Blacksmith.Validations.Exceptions;
using System;

namespace Blacksmith.Validations
{
    public class Asserts : IValidator
    {
        static Asserts()
        {
            Default = new Asserts();
        }

        protected Asserts() : base()
        {
        }

        public static IValidator Default { get; }

        public void fail()
        {
            throw new FailAssertException();
        }

        public void isFalse(bool condition)
        {
            prv_validate(condition == false, () => new FalseExpectedAssertException());
        }

        public void isTrue(bool condition)
        {
            prv_validate(condition, () => new TrueExpectedAssertException());
        }

        public void isInstanceOf<T>(object item)
        {
            prv_validate(item != null, () => new NotNullExpectedObjectAssertException());
            prv_validate(item is T, () => new ExpectedTypeAssertException(item.GetType(), typeof(T)));
        }

        public void isNotNull<T>(T item) where T : class
        {
            prv_validate(item != null, () => new NotNullExpectedObjectAssertException());
        }

        public void isNull<T>(T item) where T : class
        {
            prv_validate(item == null, () => new NullExpectedObjectAssertException());
        }

        public void isValidEnum<T>(T enumValue) where T : struct
        {
            prv_validate(Enum.IsDefined(typeof(T), enumValue), () => new ValidEnumValueExpectedAssertException(typeof(T)));
        }

        public void isValidEnumeration<T>(T value) where T : Enumeration
        {
            prv_validate(value != null, () => new NotNullExpectedObjectAssertException());
            prv_validate(Enumeration.isDefined(value), () => new ValidEnumerationObjectExpectedAssertException(enumerationType: typeof(T)));
        }

        private static void prv_validate(bool condition, Func<AssertException> buildException)  
        {
            if (condition == false)
            {
                throw buildException();
            }
        }
    }
}