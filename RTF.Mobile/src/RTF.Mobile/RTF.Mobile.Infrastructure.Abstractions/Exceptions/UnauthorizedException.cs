using System;
using System.Runtime.Serialization;

namespace RTF.Mobile.Infrastructure.Abstractions.Exceptions
{
    public class UnauthorizedException : ApplicationException
    {
        public UnauthorizedException(string message) : base(message)
        {
        }

        public UnauthorizedException(string message, int code) : base(message, code)
        {
        }

        public UnauthorizedException(string message, string code) : base(message, code)
        {
        }

        public UnauthorizedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public UnauthorizedException(string message, Exception innerException, int code) : base(message, innerException, code)
        {
        }

        public UnauthorizedException(string message, Exception innerException, string code) : base(message, innerException, code)
        {
        }

        protected UnauthorizedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
