using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lalosoft.Common.Exceptions;


namespace Lalosoft.Profiles.Common.Exceptions
{
  public class LalosoftNoAppDirectorySetException : LalosException
  {
     public LalosoftNoAppDirectorySetException()
            : base()
        {
        }

        public LalosoftNoAppDirectorySetException(string message)
            : base(message)
        {
        }

        public LalosoftNoAppDirectorySetException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public LalosoftNoAppDirectorySetException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
  }
}
