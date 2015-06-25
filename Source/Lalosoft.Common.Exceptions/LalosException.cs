using System;
using System.Collections.Generic;
using System.Text;

namespace Lalosoft.Common.Exceptions
{
    public class LalosException : Exception
    {
        public LalosException()
            : base()
        {
        }

        public LalosException(string message)
            : base(message)
        {
        }

        public LalosException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public LalosException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}
