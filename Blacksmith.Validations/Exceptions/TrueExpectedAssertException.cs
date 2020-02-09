using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Blacksmith.Validations.Exceptions
{
    [Serializable]
    public class TrueExpectedAssertException : AssertException
    {
        public TrueExpectedAssertException(
            [CallerLineNumber] int callerLineNumber = 0
            , [CallerMemberName] string callerMemberName = ""
            , [CallerFilePath] string callerFilePath = "")
            : base(callerLineNumber, callerMemberName, callerFilePath)
        {
        }

        public TrueExpectedAssertException(
            string message
            , [CallerLineNumber] int callerLineNumber = 0
            , [CallerMemberName] string callerMemberName = ""
            , [CallerFilePath] string callerFilePath = "")
            : base(message, callerLineNumber, callerMemberName, callerFilePath)
        {
        }

        protected TrueExpectedAssertException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}