using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Blacksmith.Validations.Exceptions
{
    [Serializable]
    public class ValidEnumerationObjectExpectedAssertException : AssertException
    {
        public ValidEnumerationObjectExpectedAssertException(Type enumerationType
            , [CallerLineNumber] int callerLineNumber = 0
            , [CallerMemberName] string callerMemberName = ""
            , [CallerFilePath] string callerFilePath = "")
            : base(callerLineNumber, callerMemberName, callerFilePath)
        {
            this.EnumerationType = enumerationType;
        }

        protected ValidEnumerationObjectExpectedAssertException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public Type EnumerationType { get; }
    }
}