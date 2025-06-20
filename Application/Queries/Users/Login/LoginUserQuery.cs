using Application.Dtos.Users;
using MediatR;

namespace Application.Queries.Users.Login
{
    public class LoginUserQuery : IRequest<string>
    {
        public LoginUserQuery(UserCredentialsDto loginUser)
        {
            LoginUser = loginUser;
        }

        public UserCredentialsDto LoginUser { get; }
    }
}
