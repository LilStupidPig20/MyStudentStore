using System;
using System.Runtime.Serialization;

namespace RTF.Mobile.Infrastructure.Abstractions.Exceptions
{
    internal class InfrastructureException : ApplicationException
    {
        public InfrastructureException(string message) : base(message)
        {
        }

        public InfrastructureException(string message, int code) : base(message, code)
        {
        }

        public InfrastructureException(string message, string code) : base(message, code)
        {
        }

        public InfrastructureException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public InfrastructureException(string message, Exception innerException, int code) : base(message, innerException, code)
        {
        }

        public InfrastructureException(string message, Exception innerException, string code) : base(message, innerException, code)
        {
        }

        protected InfrastructureException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
