using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Blacksmith.Validations.Exceptions
{
    [Serializable]
    public class AssertException : Exception
    {
        public AssertException(
            [CallerLineNumber] int callerLineNumber = 0
            , [CallerMemberName] string callerMemberName = ""
            , [CallerFilePath] string callerFilePath = ""
            ) : base()
        {
            this.CallerLineNumber = callerLineNumber;
            this.CallerMemberName = callerMemberName;
            this.CallerFilePath = callerFilePath;
        }

        protected AssertException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public int CallerLineNumber { get; }
        public string CallerMemberName { get; }
        public string CallerFilePath { get; }
    }
}