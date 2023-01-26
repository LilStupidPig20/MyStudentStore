using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RTF.Mobile.Infrastructure.Abstractions.Exceptions
{
    public class NetworkException : ApplicationException
    {
        public NetworkException(string message) : base(message)
        {
        }

        public NetworkException(string message, int code) : base(message, code)
        {
        }

        public NetworkException(string message, string code) : base(message, code)
        {
        }

        public NetworkException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public NetworkException(string message, Exception innerException, int code) : base(message, innerException, code)
        {
        }

        public NetworkException(string message, Exception innerException, string code) : base(message, innerException, code)
        {
        }

        protected NetworkException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
