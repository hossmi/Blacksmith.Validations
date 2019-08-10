using System;
using System.Runtime.Serialization;

namespace Blaxpro.Validations.Exceptions
{
    public class AssertException : Exception
    {
        public AssertException(string message, int sourceLineNumber, string memberName, string sourceFilePath) : base(message)
        {
            this.SourceLineNumber = sourceLineNumber;
            this.MemberName = memberName;
            this.SourceFilePath = sourceFilePath;
        }

        protected AssertException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public int SourceLineNumber { get; }
        public string MemberName { get; }
        public string SourceFilePath { get; }
    }
}