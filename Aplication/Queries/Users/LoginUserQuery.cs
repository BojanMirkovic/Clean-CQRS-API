﻿using Application.Dtos;
using Azure.Identity;
using Domain.Models.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Users
{
    public class LoginUserQuery : IRequest<User>
    {
        public UserDto LoginUser { get; }
        public LoginUserQuery(UserDto loginUser)
        {
            LoginUser = loginUser;
        }
    }
}
