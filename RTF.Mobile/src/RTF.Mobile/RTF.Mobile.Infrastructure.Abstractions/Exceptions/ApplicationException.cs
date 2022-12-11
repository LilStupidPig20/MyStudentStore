using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RTF.Mobile.Infrastructure.Abstractions.Exceptions
{
    public class ApplicationException : Exception
    {
        public string Code { get; protected set; } = string.Empty;

        public ApplicationException(string message) : base(message)
        {
        }

        public ApplicationException(string message, int code) : base(message)
        {
            this.Code = code.ToString();
        }

        public ApplicationException(string message, string code) : base(message)
        {
            this.Code = code;
        }

        public ApplicationException(string message, Exception innerException) :
            base(message, innerException)
        {
        }

        public ApplicationException(string message, Exception innerException, int code) :
            base(message, innerException)
        {
            this.Code = code.ToString();
        }

        public ApplicationException(string message, Exception innerException, string code) :
            base(message, innerException)
        {
            this.Code = code;
        }

        protected ApplicationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.Code = info.GetString("code");
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("code", Code);
        }
    }
}
