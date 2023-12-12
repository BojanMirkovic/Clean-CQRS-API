using Domain.Models.User;
using Infrastructure.Authentication;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Users
{
    internal class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, User>
    {
        private readonly MockDatabase _mockDatabase;
        private readonly JWTtokenGenerator _jwtTokenGenerator;

        public LoginUserQueryHandler(MockDatabase mockDatabase, JWTtokenGenerator jwtTokenGenerator)
        {
            _mockDatabase = mockDatabase;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public Task<User> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            User wantedUser = _mockDatabase.Users.FirstOrDefault(user => user.Username == request.LoginUser.UserName)!;

            if (wantedUser == null)
            {
                return Task.FromResult<User>(null!);
            }

            wantedUser.token = _jwtTokenGenerator.CreateJWTtoken(wantedUser);

            return Task.FromResult(wantedUser);
        }
    }
}
