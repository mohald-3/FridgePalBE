using Application.Dtos.Users;
using Domain.Models.User;
using MediatR;


namespace Application.Commands.Users.Register
{
    public class RegisterUserCommand : IRequest<UserModel>
    {
        public RegisterUserCommand(UserCredentialsDto newUser)
        {
            NewUser = newUser;
        }

        public UserCredentialsDto NewUser { get; }
    }
}
