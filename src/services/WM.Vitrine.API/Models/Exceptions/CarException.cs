using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WM.Vitrine.API.Models.Models.Exceptions
{
    public class CarException : Exception
    {
        public CarException()
        {
        }

        public CarException(string message) : base(message)
        {
        }

        public CarException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CarException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
