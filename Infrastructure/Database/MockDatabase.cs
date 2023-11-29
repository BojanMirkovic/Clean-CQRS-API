using Domain.Models.Animal;

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
            new Dog { Id=Guid.NewGuid(), Name="Astor"},
            new Dog { Id=Guid.NewGuid(), Name="Ari" },
            new Dog { Id=Guid.NewGuid(), Name="Max" },
            new Dog { Id=Guid.NewGuid(), Name="Rex" },
            new Dog { Id=Guid.NewGuid(), Name="Miki" },
            new Dog { Id = new Guid("12345678-1234-5678-1234-567812345678"), Name = "TestDogForUnitTests"}
        };

        public List<Cat> allCatsFromMockDatabase = new()
        {
            new Cat { Id=Guid.NewGuid(), Name="Kity", LikesToPlay=true},
            new Cat { Id=Guid.NewGuid(), Name="Micko", LikesToPlay = true},
            new Cat { Id=Guid.NewGuid(), Name="Azrael", LikesToPlay=false },
            new Cat { Id = new Guid("12345678-1234-5678-1234-567812345680"), Name = "TestCatForUnitTests", LikesToPlay=false}
        };

        public List<Bird> allBirdsFromMockDatabase = new()
        {
            new Bird { Id=Guid.NewGuid(), Name="Ara", CanFly=false},
            new Bird { Id=Guid.NewGuid(), Name="Vrana", CanFly=true},
            new Bird { Id=Guid.NewGuid(), Name="Sova", CanFly=true},
            new Bird { Id = new Guid("12345678-1234-5678-1234-567812345682"), Name = "TestBirdForUnitTests", CanFly=false}

        };
    };
}
