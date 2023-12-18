using BCrypt.Net;
using Domain.Models.AnimalModel;
using Domain.Models.UserModel;

namespace Infrastructure.Database
{
    public class MockDatabase
    {
        public List<Dog> Dogs
        {
            get { return allDogsFromMockDatabase; }
            set { allDogsFromMockDatabase = value; }
        }
        public List<Cat> Cats
        {
            get { return allCatsFromMockDatabase; }
            set { allCatsFromMockDatabase = value; }
        }

        public List<Bird> Birds
        {
            get { return allBirdsFromMockDatabase; }
            set { allBirdsFromMockDatabase = value; }
        }

        public List<Dog> allDogsFromMockDatabase = new()
        {
            new Dog { AnimalId=Guid.NewGuid(), Name="Astor", Breed="English Pointer" , Weight= 28 },
            new Dog { AnimalId=Guid.NewGuid(), Name="Ari", Breed="English Pointer" , Weight= 31 },
            new Dog { AnimalId=Guid.NewGuid(), Name="Max",Breed="German Shepherd" , Weight= 37},
            new Dog { AnimalId = new Guid("12345678-1234-5678-1234-567812345678"), Name = "TestDogForUnitTests",Breed="German Terrire" , Weight= 9}
        };

        public List<Cat> allCatsFromMockDatabase = new()
        {
            new Cat { AnimalId=Guid.NewGuid(), Name="Kity", LikesToPlay=true, Breed="Persian Cat" , Weight= 4},
            new Cat { AnimalId=Guid.NewGuid(), Name="Micko", LikesToPlay = true, Breed="Domestic Cat" , Weight= 6},
            new Cat { AnimalId=Guid.NewGuid(), Name="Azrael", LikesToPlay=false, Breed="Siamese Cat" , Weight= 6 },
            new Cat { AnimalId = new Guid("12345678-1234-5678-1234-567812345680"), Name = "TestCatForUnitTests", LikesToPlay=false, Breed="Domestic Cat" , Weight= 6}
        };

        public List<Bird> allBirdsFromMockDatabase = new()
        {
            new Bird { AnimalId=Guid.NewGuid(), Name="Ara", CanFly=false, Color="Red"},
            new Bird { AnimalId=Guid.NewGuid(), Name="Vrana", CanFly=true, Color="Black"},
            new Bird { AnimalId=Guid.NewGuid(), Name="Sova", CanFly=true, Color="Grey"},
            new Bird { AnimalId = new Guid("12345678-1234-5678-1234-567812345682"), Name = "TestBirdForUnitTestDelete", CanFly=false, Color="blue"},
            new Bird { AnimalId = new Guid("12345680-1224-5878-1234-667812345690"), Name = "TestBirdForUnitTestUpdate", CanFly=false, Color="blue"}

        };
        public List<User> Users
        {
            get { return allUsers; }
            set { allUsers = value; }
        }

        private static List<User> allUsers = new()
        {
            new User { UserId = new Guid("08260479-52a0-4c0e-a588-274101a2c3be"), Username = "Bojan", Password = BCrypt.Net.BCrypt.HashPassword("Bojan123"), Role = "admin" },
            new User { UserId = new Guid("047425eb-15a5-4310-9d25-e281ab036868"), Username = "NotAnAdmin", Password = BCrypt.Net.BCrypt.HashPassword("Bojan123"), Role = "user"},
            new User { UserId = new Guid("047425eb-15a5-4310-9d25-e281ab036869"), Username = "TestUser", Password = BCrypt.Net.BCrypt.HashPassword("Bojan123"), Role = "user"}
        };
    };
}
