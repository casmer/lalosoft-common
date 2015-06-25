using System;
using System.Collections.Generic;
using System.Text;


namespace Lalosoft.Common.Exceptions
{
    public class LalosSecurityException: LalosException
    {
        public LalosSecurityException()
            : base()
        {
        }

        public LalosSecurityException(string message)
            : base(message)
        {
        }

        public LalosSecurityException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public LalosSecurityException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}
