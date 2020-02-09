using Blacksmith.Validations.Exceptions;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Blacksmith.Validations.Exceptions
{
    [Serializable]
    public class NullOrEmptyStringAssertException : AssertException
    {
        public NullOrEmptyStringAssertException(
            [CallerLineNumber] int callerLineNumber = 0
            , [CallerMemberName] string callerMemberName = ""
            , [CallerFilePath] string callerFilePath = "") 
            : base(callerLineNumber, callerMemberName, callerFilePath)
        {
        }

        protected NullOrEmptyStringAssertException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}