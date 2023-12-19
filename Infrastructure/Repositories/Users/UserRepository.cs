using Domain.Models.UserModel;
using Infrastructure.Database;

namespace Infrastructure.Repositories.Users
{
    internal class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(RealDb context) : base(context) { }
    }
}
