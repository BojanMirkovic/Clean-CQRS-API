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

        public List<Dog> allDogsFromMockDatabase = new()
        {
            new Dog { Id=Guid.NewGuid(), Name="Astor"},
            new Dog { Id=Guid.NewGuid(), Name="Ari" },
            new Dog { Id=Guid.NewGuid(), Name="Max" },
            new Dog { Id=Guid.NewGuid(), Name="Rex" },
            new Dog { Id = new Guid("12345678-1234-5678-1234-567812345678"), Name = "TestDogForUnitTests"}
        };
        
    };
}
