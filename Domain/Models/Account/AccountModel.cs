using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Account
{
    public abstract class AccountModel
    {
        public Guid Id { get; set; }

        public required string Username { get; set; }

        public required string Password { get; set; }
    }
}
