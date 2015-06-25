using System;
using System.Collections.Generic;
using System.Text;


namespace Lalosoft.Common.Exceptions
{
    public class LalosInvalidPasswordException: LalosException
    {
        public LalosInvalidPasswordException()
            : base()
        {
        }

        public LalosInvalidPasswordException(string message)
            : base(message)
        {
        }

        public LalosInvalidPasswordException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public LalosInvalidPasswordException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}
