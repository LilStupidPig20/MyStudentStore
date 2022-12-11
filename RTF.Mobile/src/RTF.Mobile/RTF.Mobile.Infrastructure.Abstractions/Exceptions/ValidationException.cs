using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RTF.Mobile.Infrastructure.Abstractions.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public ValidationException(string message) : base(message)
        {
        }

        public ValidationException(string message, int code) : base(message, code)
        {
        }

        public ValidationException(string message, string code) : base(message, code)
        {
        }

        public ValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ValidationException(string message, Exception innerException, int code) : base(message, innerException, code)
        {
        }

        public ValidationException(string message, Exception innerException, string code) : base(message, innerException, code)
        {
        }

        protected ValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
