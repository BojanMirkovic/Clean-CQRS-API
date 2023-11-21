using Domain.Models;

namespace Infrastructure.Database
{
    public class MockDatabase
    {
        public List<Dog> allDogs
        {
            get { return allDogsFromMockDatabase; }
            set { allDogsFromMockDatabase = value; }
        }

        public List<Dog> allDogsFromMockDatabase = new()
        {
            new Dog
            {
                animalId=Guid.NewGuid(), Name="PeppLeDog"
            },
            new Dog
            {
                animalId=Guid.NewGuid(), Name="PepGuardiol"
            },
            new Dog
            {
                animalId=Guid.NewGuid(), Name="Max"
            },
            new Dog
            {
                animalId=Guid.NewGuid(), Name="Rex"
            },

        };
        
    };
}
