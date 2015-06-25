using System;
using System.Collections.Generic;
using System.Text;

namespace Lalosoft.Common.Exceptions
{
    public class LalosConfigurationException: LalosException
    {
        public LalosConfigurationException()
            : base()
        {
        }

        public LalosConfigurationException(string message)
            : base(message)
        {
        }

        public LalosConfigurationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public LalosConfigurationException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}
