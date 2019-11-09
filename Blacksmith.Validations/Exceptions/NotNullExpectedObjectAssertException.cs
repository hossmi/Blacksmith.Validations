using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Blacksmith.Validations.Exceptions
{
    [Serializable]
    public class NotNullExpectedObjectAssertException : AssertException
    {
        public NotNullExpectedObjectAssertException(
            [CallerLineNumber] int callerLineNumber = 0
            , [CallerMemberName] string callerMemberName = ""
            , [CallerFilePath] string callerFilePath = "")
            : base(callerLineNumber, callerMemberName, callerFilePath)
        {
        }

        protected NotNullExpectedObjectAssertException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}