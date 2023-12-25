using Domain.Models.AnimalModel;
using Domain.Models.UserModel;

namespace Infrastructure.Repositories.Users
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User?> GetTokenForUserByUsername(string username);
        Task<User> GetUserById(Guid id);
        Task<User> RegisterUser(User newUser);
        Task<User> UpdateUser(User updateUser);
        Task<User> DeleteUser(Guid id);
        Task<string> GetsTokenToLogin(string userName, string password);
    }
}
