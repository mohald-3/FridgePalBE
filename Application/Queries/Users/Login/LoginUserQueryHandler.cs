﻿using Application.Dtos.Users;
using Infrastructure.Repositories.Authorization;
using MediatR;

namespace Application.Queries.Users.Login
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, string>
    {
        private readonly AuthRepository _authRepository;

        public LoginUserQueryHandler(AuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public Task<string> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = _authRepository.AuthenticateUser(request.LoginUser.Username, request.LoginUser.Password);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid username or password");
            }

            string token = _authRepository.GenerateJwtToken(user);

            return Task.FromResult(token);
        }
    }
}

