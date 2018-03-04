using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Desktop.Exceptions
{
    class DataBaseException : Exception
    {
        public DataBaseException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
