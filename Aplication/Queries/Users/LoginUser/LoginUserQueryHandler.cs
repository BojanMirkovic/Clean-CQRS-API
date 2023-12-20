using Application.Exceptions;
using Domain.Models.UserModel;
using Infrastructure.Authentication;
using Infrastructure.Database;
using MediatR;
using System.Security.Authentication;

namespace Application.Queries.Users.LoginUser
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, string>
    {
        private readonly MockDatabase _mockDatabase;
        private readonly JWTtokenGenerator _jwtTokenGenerator;

        public LoginUserQueryHandler(MockDatabase mockDatabase, JWTtokenGenerator jwtTokenGenerator)
        {
            _mockDatabase = mockDatabase;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public Task<string> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            User? wantedUser = _mockDatabase.Users.FirstOrDefault(user => user.Username == request.LoginUser.UserName);




            if (wantedUser == null || !BCrypt.Net.BCrypt.Verify(request.LoginUser.Password, wantedUser.Password))
            {
                throw new UnauthorizedAccessException("Invalid username or password");
            }

            try
            {
                var token = _jwtTokenGenerator.CreateJWTtoken(wantedUser);
                return Task.FromResult(token);
            }
            catch (AuthenticationException ex)
            {
                throw new AuthenticationException("Invalid user data. Username and password are required.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to generate token.", ex);
            }

        }
    }
}
