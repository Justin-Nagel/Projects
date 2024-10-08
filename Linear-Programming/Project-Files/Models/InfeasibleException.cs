﻿using System;

namespace Models
{

    [Serializable]
    public class InfeasibleException : Exception
    {
        public InfeasibleException() { }
        public InfeasibleException(string message) : base(message) { }
        public InfeasibleException(string message, Exception inner) : base(message, inner) { }
        protected InfeasibleException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
