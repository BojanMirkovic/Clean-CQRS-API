using Domain.Models.UserModel;
using Infrastructure.Database;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories
{
    internal class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(RealDb context) : base(context) { }
    }
}
