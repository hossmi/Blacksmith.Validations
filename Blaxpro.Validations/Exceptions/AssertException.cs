﻿using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Blaxpro.Validations.Exceptions
{
    public class AssertException : Exception
    {
        public AssertException(string message
            , [CallerLineNumber] int callerLineNumber = 0
            , [CallerMemberName] string callerMemberName = ""
            , [CallerFilePath] string callerFilePath = ""
            ) : base(message)
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