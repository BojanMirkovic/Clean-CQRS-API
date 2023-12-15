using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class BaseCustomException : Exception
    {
        public BaseCustomException() { }

        public BaseCustomException(string message) : base(message) { }

        public BaseCustomException(string message, Exception inner) : base(message, inner) { }
    }
}
