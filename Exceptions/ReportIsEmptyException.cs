using System;
using System.Runtime.Serialization;

namespace EMS.Desktop.Exceptions
{
    [Serializable]
    internal class ReportIsEmptyException : Exception
    {
        public int ServiceId;

        public ReportIsEmptyException(int serviceId)
        {
            ServiceId = serviceId;
        }

        public ReportIsEmptyException(string message) : base(message)
        {
        }

        public ReportIsEmptyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ReportIsEmptyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}