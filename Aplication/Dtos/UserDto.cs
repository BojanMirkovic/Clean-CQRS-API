using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    //we are using Dto to send data to API,password is simple string because we use it only to register/login
    public class UserDto
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
}
