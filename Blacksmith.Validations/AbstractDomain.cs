using Blacksmith.Validations.Exceptions;
using System;
using System.Text.RegularExpressions;

namespace Blacksmith.Validations
{
    public abstract class AbstractDomain
    {
        protected readonly IValidator assert;

        protected AbstractDomain()
        {
            this.assert = createAssertValidator();
        }

        protected virtual IValidator createAssertValidator()
        {
            return Asserts.Default;
        }

        protected virtual DomainException buildDefaultException()
        {
            return new DomainException();
        }

        protected virtual TException buildGenericException<TException>() where TException : DomainException, new()
        {
            return new TException();
        }

        protected void isTrue<TException>(bool condition) where TException : DomainException, new()
        {
            isTrue(condition, buildGenericException<TException>);
        }

        protected void isTrue(bool condition)
        {
            isTrue(condition, buildDefaultException);
        }

        protected void isTrue(bool condition, Func<DomainException> buildException)
        {
            prv_validate(condition, buildException, this.assert);
        }


        protected void stringIsNotEmpty<TException>(string someString) where TException : DomainException, new()
        {
            stringIsNotEmpty(someString, buildGenericException<TException>);
        }

        protected void stringIsNotEmpty(string someString)
        {
            stringIsNotEmpty(someString, buildDefaultException);
        }

        protected void stringIsNotEmpty(string someString, Func<DomainException> buildException)
        {
            this.assert.isNotNull(someString);
            prv_validate(string.IsNullOrWhiteSpace(someString) == false, buildException, this.assert);
        }

        protected void stringLength<TException>(string item, int minLength, int maxLength) where TException : DomainException, new()
        {
            stringLength(item, minLength, maxLength, buildGenericException<TException>);
        }

        protected void stringLength(string item, int minLength, int maxLength)
        {
            stringLength(item, minLength, maxLength, buildDefaultException);
        }

        protected void stringLength(string item, int minLength, int maxLength, Func<DomainException> buildException)
        {
            this.assert.isTrue(0 < minLength);
            this.assert.isTrue(0 < maxLength);
            this.assert.isTrue(minLength <= maxLength);
            this.assert.isNotNull(item);
            prv_validate(minLength <= item.Length && item.Length <= maxLength, buildException, this.assert);
        }

        protected void stringMatchRegex<TException>(string someString, Regex regex) where TException: DomainException, new()
        {
            stringMatchRegex(someString, regex, buildGenericException<TException>);
        }

        protected void stringMatchRegex(string someString, Regex regex)
        {
            stringMatchRegex(someString, regex, buildDefaultException);
        }

        protected void stringMatchRegex(string someString, Regex regex, Func<DomainException> buildException)
        {
            this.assert.isNotNull(someString);
            this.assert.isNotNull(regex);
            prv_validate(regex.IsMatch(someString), buildException, this.assert);
        }

        protected void stringMaxLength<TException>(string item, int maxLength) where TException: DomainException, new()
        {
            stringMaxLength(item, maxLength, buildGenericException<TException>);
        }

        protected void stringMaxLength(string item, int maxLength)
        {
            stringMaxLength(item, maxLength, buildDefaultException);
        }

        protected void stringMaxLength(string item, int maxLength, Func<DomainException> buildException)
        {
            this.assert.isNotNull(item);
            this.assert.isTrue(0 < maxLength);
            prv_validate(item.Length <= maxLength, buildException, this.assert);
        }

        protected void stringMinLength<TException>(string item, int minLength, Func<DomainException> buildException) 
            where TException : DomainException, new()
        {
            stringMinLength(item, minLength, buildGenericException<TException>);
        }

        protected void stringMinLength(string item, int minLength)
        {
            stringMinLength(item, minLength, buildDefaultException);
        }

        protected void stringMinLength(string item, int minLength, Func<DomainException> buildException)
        {
            this.assert.isNotNull(item);
            this.assert.isTrue(0 < minLength);
            prv_validate(minLength <= item.Length, buildException, this.assert);
        }

        private static void prv_validate(bool condition, Func<DomainException> buildException, IValidator assert)
        {
            if (condition == false)
            {
                DomainException exception;

                assert.isNotNull(buildException);
                exception = buildException();
                assert.isNotNull(exception);
                throw exception;
            }
        }

    }
}
