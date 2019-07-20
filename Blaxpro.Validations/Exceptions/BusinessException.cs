using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Blaxpro.Validations.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string message
            , [CallerLineNumber] int sourceLineNumber = 0
            , [CallerMemberName] string memberName = ""
            , [CallerFilePath] string sourceFilePath = "") : base(message)
        {
            this.SourceLineNumber = sourceLineNumber;
            this.MemberName = memberName ?? "";
            this.SourceFilePath = sourceFilePath ?? "";
        }

        public BusinessException(string message, Exception innerException
            , [CallerLineNumber] int sourceLineNumber = 0
            , [CallerMemberName] string memberName = ""
            , [CallerFilePath] string sourceFilePath = "") : base(message, innerException)
        {
            this.SourceLineNumber = sourceLineNumber;
            this.MemberName = memberName ?? "";
            this.SourceFilePath = sourceFilePath ?? "";
        }

        protected BusinessException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public int SourceLineNumber { get; }
        public string MemberName { get; }
        public string SourceFilePath { get; }

        public static implicit operator BusinessException(string message)
        {
            return new BusinessException(message);
        }
    }
}