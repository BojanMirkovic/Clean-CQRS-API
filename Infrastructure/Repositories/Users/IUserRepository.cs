using Domain.Models.AnimalModel;
using Domain.Models.UserModel;

namespace Infrastructure.Repositories.Users
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<string> GetToken(User userToLogin);
        Task<User> RegisterUser(User newUser);
        Task<User> UpdateUser(User updateUser);
        Task<User> DeleteUser(Guid id);
    }
}
