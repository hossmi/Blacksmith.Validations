using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Blacksmith.Validations.Exceptions
{
    [Serializable]
    public class ExpectedTypeAssertException : AssertException
    {
        public ExpectedTypeAssertException(Type sourceType, Type expectedType
            , [CallerLineNumber] int callerLineNumber = 0
            , [CallerMemberName] string callerMemberName = ""
            , [CallerFilePath] string callerFilePath = "")
            : base(callerLineNumber, callerMemberName, callerFilePath)
        {
            this.SourceType = sourceType;
            this.ExpectedType = expectedType;
        }

        protected ExpectedTypeAssertException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public Type SourceType { get; }
        public Type ExpectedType { get; }
    }
}