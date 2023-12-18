using Domain.Models.UserModel;
using MediatR;

namespace Application.Queries.Users.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<User>>
    {
    }
}
