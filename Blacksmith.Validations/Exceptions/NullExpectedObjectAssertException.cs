﻿using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Blacksmith.Validations.Exceptions
{
    [Serializable]
    public class NullExpectedObjectAssertException : AssertException
    {
        public NullExpectedObjectAssertException(
            [CallerLineNumber] int callerLineNumber = 0
            , [CallerMemberName] string callerMemberName = ""
            , [CallerFilePath] string callerFilePath = "")
            : base(callerLineNumber, callerMemberName, callerFilePath)
        {
        }

        protected NullExpectedObjectAssertException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}