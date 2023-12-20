using Domain.Models.UserModel;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Users
{
    internal class UserRepository : IUserRepository
    {
        private readonly RealDb _sqlDatabase;

        public UserRepository(RealDb sqlDatabase)
        {
            _sqlDatabase = sqlDatabase;
        }

        public async Task<User> DeleteUser(Guid id)
        {
            try
            {
                User userToDelete = await GetUserById(id);

                _sqlDatabase.Users.Remove(userToDelete);

                _sqlDatabase.SaveChanges();

                return await Task.FromResult(userToDelete);
            }
            catch (Exception ex)
            {

                throw new Exception($"An error occured while deleting a user with Id {id} from the database", ex);
            }
        }
        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                return await _sqlDatabase.Users.ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("An error occured while getting all users from the database", ex);
            }
        }

        public async Task<User?> GetTokenForUserByUsername(string username)
        {
            var userFromDB = await _sqlDatabase.Users.FirstOrDefaultAsync(user => user.Username == username);
            if (userFromDB == null) 
            {
                throw new Exception($"There was no user with name {username} in the database");
            }
            return userFromDB;

           
        }

        public async Task<User> GetUserById(Guid id)
        {
            try
            {
                User? wantedUser = await _sqlDatabase.Users.FirstOrDefaultAsync(user => user.UserId == id);

                if (wantedUser == null)
                {
                    throw new Exception($"There was no user with Id {id} in the database");
                }

                return await Task.FromResult(wantedUser);
            }
            catch (Exception ex)
            {

                throw new Exception($"An error occured while getting a user with Id {id} from database", ex);
            }
        }

        public async Task<User> RegisterUser(User newUser)
        {
            try
            {
                _sqlDatabase.Users.Add(newUser);
                _sqlDatabase.SaveChanges();
                return await Task.FromResult(newUser);
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
        }

        public Task<User> UpdateUser(User updateUser)
        {
            try
            {
                _sqlDatabase.Users.Update(updateUser);

                _sqlDatabase.SaveChanges();

                return Task.FromResult(updateUser);
            }
            catch (Exception ex)
            {

                throw new Exception($"An error occured while updating a user by Id {updateUser.UserId} from database", ex);
            }
        }
    }
}
