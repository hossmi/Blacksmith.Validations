using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Blacksmith.Validations.Exceptions
{
    [Serializable]
    public class FalseExpectedAssertException : AssertException
    {
        public FalseExpectedAssertException(
            [CallerLineNumber] int callerLineNumber = 0
            , [CallerMemberName] string callerMemberName = ""
            , [CallerFilePath] string callerFilePath = "")
            : base(callerLineNumber, callerMemberName, callerFilePath)
        {
        }

        public FalseExpectedAssertException(
            string message
            , [CallerLineNumber] int callerLineNumber = 0
            , [CallerMemberName] string callerMemberName = ""
            , [CallerFilePath] string callerFilePath = "")
            : base(message, callerLineNumber, callerMemberName, callerFilePath)
        {
        }

        protected FalseExpectedAssertException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}