using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class UnAuthorizedException : BaseCustomException
    {
        public UnAuthorizedException()
            : base("You are not authorized to perform this action.")
        {
        }
    }
}
