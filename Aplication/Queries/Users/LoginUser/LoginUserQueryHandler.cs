﻿using Domain.Models.UserModel;
using Infrastructure.Authentication;
using Infrastructure.Repositories.Users;
using MediatR;
using System.Security.Authentication;

namespace Application.Queries.Users.LoginUser
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, string>
    {
        private readonly IUserRepository _userRepository;
        // private readonly JWTtokenGenerator _jwtTokenGenerator;

        public LoginUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }

        public async Task<string> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            string jwtToken = await _userRepository.GetsTokenToLogin(request.LoginUser.UserName, request.LoginUser.Password);
            if (jwtToken == null)
            {
                return null!;
            }
            return jwtToken;
            //User? wantedUser = await _userRepository.GetTokenForUserByUsername(request.LoginUser.UserName);

            //if (wantedUser == null || !BCrypt.Net.BCrypt.Verify(request.LoginUser.Password, wantedUser.Password))
            //{
            //    throw new UnauthorizedAccessException("Invalid username or password");
            //}

            //try
            //{
            //    var token = _jwtTokenGenerator.CreateJWTtoken(wantedUser);
            //    return token;
            //}
            //catch (AuthenticationException ex)
            //{
            //    throw new AuthenticationException("Invalid user data. Username and password are required.", ex);
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("Failed to generate token.", ex);
            //}

        }
    }
}
