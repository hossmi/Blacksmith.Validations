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
            validate(condition == false, () => new FalseExpectedAssertException());
        }

        public void isTrue(bool condition)
        {
            validate(condition, () => new TrueExpectedAssertException());
        }

        public void isInstanceOf<T>(object item)
        {
            validate(item != null, () => new NotNullExpectedObjectAssertException());
            validate(item is T, () => new ExpectedTypeAssertException(item.GetType(), typeof(T)));
        }

        public void isNotNull<T>(T item) where T : class
        {
            validate(item != null, () => new NotNullExpectedObjectAssertException());
        }

        public void isNull<T>(T item) where T : class
        {
            validate(item == null, () => new NullExpectedObjectAssertException());
        }

        public void isValidEnum<T>(T enumValue) where T : struct
        {
            validate(Enum.IsDefined(typeof(T), enumValue), () => new ValidEnumValueExpectedAssertException(typeof(T)));
        }

        public void isValidEnumeration<T>(T value) where T : Enumeration
        {
            validate(value != null, () => new NotNullExpectedObjectAssertException());
            validate(Enumeration.isDefined(value), () => new ValidEnumerationObjectExpectedAssertException(enumerationType: typeof(T)));
        }

        private static void validate(bool condition, Func<AssertException> buildException)  
        {
            if (condition == false)
            {
                throw buildException();
            }
        }
    }
}