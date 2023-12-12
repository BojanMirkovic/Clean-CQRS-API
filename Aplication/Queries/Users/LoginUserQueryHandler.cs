using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Users
{
    internal class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, string>
    {
        public Task<string> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
