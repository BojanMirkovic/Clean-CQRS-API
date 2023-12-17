using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class UserUpdateDto : UserDto
    {
        public string Role { get; set; } = string.Empty;
    }
}
