using Domain.Models;
using Domain.Models.AnimalModel;
using Domain.Models.UserAnimalModel;
using Domain.Models.UserModel;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.DatabaseHelpers
{
    public static class DatabaseSeedHelper
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            SeedDogs(modelBuilder);
            SeedCats(modelBuilder);
            SeedBirds(modelBuilder);
            SeedUsers(modelBuilder);
            SeedUsersHaveAnimals(modelBuilder);

            // Add more methods for other entities as needed
        }

        private static void SeedUsersHaveAnimals(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsersHaveAnimals>().HasData(
                new UsersHaveAnimals { Id = -1, UserId = new Guid("08260479-52a0-4c0e-a588-274101a2c3be"), AnimalId = new Guid("12345678-1234-5678-1234-567812345682") },
                new UsersHaveAnimals { Id = -2, UserId = new Guid("08260479-52a0-4c0e-a588-274101a2c3be"), AnimalId = new Guid("12345680-1224-5878-1234-667812345690") },
                new UsersHaveAnimals { Id = -3, UserId = new Guid("047425eb-15a5-4310-9d25-e281ab036868"), AnimalId = new Guid("12345678-1234-5678-1234-567812345682") },
                new UsersHaveAnimals { Id = -4, UserId = new Guid("047425eb-15a5-4310-9d25-e281ab036868"), AnimalId = new Guid("12345680-1224-5878-1234-667812345690") }
                );


        }

        private static void SeedUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                 new User { UserId = new Guid("08260479-52a0-4c0e-a588-274101a2c3be"), Username = "Bojan", Password = BCrypt.Net.BCrypt.HashPassword("Bojan123"), Role = "admin" },
            new User { UserId = new Guid("047425eb-15a5-4310-9d25-e281ab036868"), Username = "NotAnAdmin", Password = BCrypt.Net.BCrypt.HashPassword("Bojan123"), Role = "user" },
            new User { UserId = new Guid("047425eb-15a5-4310-9d25-e281ab036869"), Username = "TestUser", Password = BCrypt.Net.BCrypt.HashPassword("Bojan123"), Role = "user" }
            );
        }

        private static void SeedBirds(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bird>().HasData(
                 new Bird { AnimalId = Guid.NewGuid(), Name = "Ara", CanFly = false, Color = "Red" },
            new Bird { AnimalId = Guid.NewGuid(), Name = "Vrana", CanFly = true, Color = "Black" },
            new Bird { AnimalId = Guid.NewGuid(), Name = "Sova", CanFly = true, Color = "Grey" },
            new Bird { AnimalId = new Guid("12345678-1234-5678-1234-567812345682"), Name = "TestBirdForUnitTestBird1", CanFly = false, Color = "blue" },
            new Bird { AnimalId = new Guid("12345680-1224-5878-1234-667812345690"), Name = "TestBirdForUnitTestBird2", CanFly = false, Color = "blue" }
            );
        }

        private static void SeedCats(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cat>().HasData(
                 new Cat { AnimalId = Guid.NewGuid(), Name = "Kity", LikesToPlay = true, Breed = "Persian Cat", Weight = 4 },
            new Cat { AnimalId = Guid.NewGuid(), Name = "Micko", LikesToPlay = true, Breed = "Domestic Cat", Weight = 6 },
            new Cat { AnimalId = Guid.NewGuid(), Name = "Azrael", LikesToPlay = false, Breed = "Siamese Cat", Weight = 6 },
            new Cat { AnimalId = new Guid("12345678-1234-5678-1234-567812345680"), Name = "TestCatForUnitTests", LikesToPlay = false, Breed = "Domestic Cat", Weight = 6 }
            );
        }

        private static void SeedDogs(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dog>().HasData(
         new Dog { AnimalId = Guid.NewGuid(), Name = "Astor", Breed = "English Pointer", Weight = 28 },
              new Dog { AnimalId = Guid.NewGuid(), Name = "Ari", Breed = "English Pointer", Weight = 31 },
              new Dog { AnimalId = Guid.NewGuid(), Name = "Max", Breed = "German Shepherd", Weight = 37 },
              new Dog { AnimalId = new Guid("12345678-1234-5678-1234-567812345678"), Name = "TestDogForUnitTests", Breed = "German Terrire", Weight = 9 }
            );
        }
    }
}
