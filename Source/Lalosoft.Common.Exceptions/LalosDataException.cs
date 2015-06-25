using System;
using System.Collections.Generic;
using System.Text;

namespace Lalosoft.Common.Exceptions
{
    public class LalosDataException : LalosException
    {
        public LalosDataException()
            : base()
        {
        }

        public LalosDataException(string message)
            : base(message)
        {
        }

        public LalosDataException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public LalosDataException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}
