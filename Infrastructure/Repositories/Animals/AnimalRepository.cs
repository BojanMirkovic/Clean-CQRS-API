using Domain.Models.AnimalModel;
using Domain.Models.UserAnimalModel;
using Domain.Models.UserModel;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Animals
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly RealDb _sqlDatabase;

        public AnimalRepository(RealDb sqlDatabase)
        {
            _sqlDatabase = sqlDatabase;
        }
        public async Task<UsersHaveAnimals> AddConnection(Guid userId, Guid animalId)
        {
            try
            {
                var connectionToCreate = new UsersHaveAnimals
                {
                    UserId = userId,
                    AnimalId = animalId
                };

                _sqlDatabase.UsersHaveAnimals.Add(connectionToCreate);

                await _sqlDatabase.SaveChangesAsync(); // Use SaveChangesAsync for an asynchronous operation

                return connectionToCreate;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred when adding a connection between user with Id {userId} and animal with Id {animalId}", ex);
            }
        }
        public async Task<UsersHaveAnimals> DeleteConnection(Guid userId, Guid animalId)
        {
            try
            {
                UsersHaveAnimals? connectionToDelete = await _sqlDatabase.UsersHaveAnimals
                    .Where(u => u.UserId == userId && u.AnimalId == animalId)
                    .FirstOrDefaultAsync();

                if (connectionToDelete == null)
                {
                    throw new Exception("There is no connection between the provided user and animal in the database");
                }

                _sqlDatabase.UsersHaveAnimals.Remove(connectionToDelete);

                await _sqlDatabase.SaveChangesAsync(); // Use SaveChangesAsync for an asynchronous operation

                return connectionToDelete;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting the connection between {userId} and {animalId}", ex);
            }
        }


        public async Task<List<Animal>> GetAllAnimals()
        {
            try
            {
                return await _sqlDatabase.Animals.ToListAsync();

            }
            catch (Exception ex)
            {

                throw new Exception("An error occured while getting all animals in database", ex);
            }
        }
        public async Task<List<UserAnimalData>> GetAllAnimalsByUserId(Guid id)
        {
            try
            {
                var usersHaveAnimals = await _sqlDatabase.UsersHaveAnimals.ToListAsync();
                var animals = await _sqlDatabase.Animals.ToListAsync();

                var userId = id;

                var queryResult = (from uha in usersHaveAnimals
                                   join a in animals on uha.AnimalId equals a.AnimalId
                                   where uha.UserId == userId
                                   select new UserAnimalData
                                   {
                                       UserId = uha.UserId,
                                       AnimalId = uha.AnimalId,
                                       AnimalName = a.Name,
                                       AnimalType = a.AnimalType
                                   }).ToList();

                return queryResult;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while getting all animals for user with id {id}", ex);
            }
        }

        public async Task<Animal> GetAnimalById(Guid id)
        {
            try
            {
                Animal? wantedAnimal = await _sqlDatabase.Animals.FirstOrDefaultAsync(animal => animal.AnimalId == id);

                if (wantedAnimal == null)
                {
                    throw new Exception($"There was no animal with Id {id} in the database");
                }

                return await Task.FromResult(wantedAnimal);
            }
            catch (Exception ex)
            {

                throw new Exception($"An error occured while getting a dog with Id {id} from database", ex);
            }
        }

        public async Task<List<UsersHaveAnimals>> GetUsersHaveAnimalsByUserId(Guid userId)
        {
            // Retrieve user-animal relationships by UserId using EF Core
            return await _sqlDatabase.UsersHaveAnimals
                .Where(uha => uha.UserId == userId)
                .ToListAsync();
        }
    }
}
