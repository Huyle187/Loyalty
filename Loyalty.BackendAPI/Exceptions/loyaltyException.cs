using System;
using System.Collections.Generic;
using System.Text;

namespace Loyalty.BackendAPI.Exceptions
{
    public class loyaltyException : Exception
    {
        public loyaltyException()
        { }

        public loyaltyException(string message)
            : base(message) { }

        public loyaltyException(string message, Exception inner)
            : base(message, inner) { }
    }
}