using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Blacksmith.Validations.Exceptions
{
    [Serializable]
    public class ValidEnumValueExpectedAssertException : AssertException
    {
        public ValidEnumValueExpectedAssertException(Type enumType
            , [CallerLineNumber] int callerLineNumber = 0
            , [CallerMemberName] string callerMemberName = ""
            , [CallerFilePath] string callerFilePath = "")
            : base(callerLineNumber, callerMemberName, callerFilePath)
        {
            this.EnumType = enumType;
        }

        protected ValidEnumValueExpectedAssertException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public Type EnumType { get; }
    }
}