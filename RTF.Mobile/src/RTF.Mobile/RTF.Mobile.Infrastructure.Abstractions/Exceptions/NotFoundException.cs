using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RTF.Mobile.Infrastructure.Abstractions.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string message, int code) : base(message, code)
        {
        }

        public NotFoundException(string message, string code) : base(message, code)
        {
        }

        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public NotFoundException(string message, Exception innerException, int code) : base(message, innerException, code)
        {
        }

        public NotFoundException(string message, Exception innerException, string code) : base(message, innerException, code)
        {
        }

        protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
