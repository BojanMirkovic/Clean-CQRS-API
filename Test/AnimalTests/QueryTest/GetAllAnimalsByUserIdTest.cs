using Application.Queries.Animals.GetAllAnimals;
using Application.Queries.Animals.GetAllAnimalsOfSameUserById;
using Domain.Models.AnimalModel;
using Domain.Models.UserAnimalModel;
using FakeItEasy;
using Infrastructure.Repositories.Animals;

namespace Test.AnimalTests.QueryTest
{
    internal class GetAllAnimalsByUserIdTest
    {


        [Test]
        public async Task GetAnimalsByUserIdQueryHandler_ReturnsFilteredAnimalsForUser()
        {
            // Arrange
            var userId = new Guid("08260479-52a0-4c0e-a588-274101a2c3be");

            // Simulate userAnimals data associated with the provided userId
            var userAnimalsForUser = new List<UsersHaveAnimals>
             {
              new UsersHaveAnimals { UserId = userId, AnimalId = new Guid("12345678-1234-5678-1234-567812345682") },
              new UsersHaveAnimals { UserId = userId, AnimalId = new Guid("12345678-1234-5678-1234-567812345690") },
              new UsersHaveAnimals { UserId = userId, AnimalId = new Guid("12345678-1234-5678-1234-567812345678") },
              new UsersHaveAnimals { UserId = new Guid("047425eb-15a5-4310-9d25-e281ab036868"), AnimalId = new Guid("12345678-1234-5678-1234-567812345680") }
            };

            // Simulate animals associated with the provided userId
            var animalsForUser = new List<Animal>
            {
              new Bird { AnimalId = new Guid("12345678-1234-5678-1234-567812345682"), Name = "Vrabac", Color = "Brown", CanFly = true },
              new Bird { AnimalId = new Guid("12345678-1234-5678-1234-567812345690"), Name = "Penguin", Color = "Black and White", CanFly = false },
              new Dog { AnimalId = new Guid("12345678-1234-5678-1234-567812345678"), Name = "Ari", Breed = "English Pointer", Weight = 27 },
              new Cat { AnimalId = new Guid("12345678-1234-5678-1234-567812345680"), Name = "Tom", Breed = "Domestic Cat", Weight = 3, LikesToPlay = false }
            };
            // Expected result query lista
            var resultAnimals = new List<UserAnimalData>
            {
                new UserAnimalData { UserId = new Guid("08260479-52a0-4c0e-a588-274101a2c3be"), AnimalId = new Guid("12345678-1234-5678-1234-567812345682"), AnimalName="Vrabac", AnimalType="Bird" },
                new UserAnimalData { UserId = new Guid("08260479-52a0-4c0e-a588-274101a2c3be"), AnimalId = new Guid("12345678-1234-5678-1234-567812345690"),AnimalName = "Penguin",AnimalType="Bird" },
                new UserAnimalData { UserId = new Guid("08260479-52a0-4c0e-a588-274101a2c3be"), AnimalId = new Guid("12345678-1234-5678-1234-567812345678"), AnimalName = "Ari",AnimalType="Dog" }
            };
            var animalRepository = A.Fake<IAnimalRepository>();

            // Mock the behavior of GetUsersHaveAnimalsByUserId method
            A.CallTo(() => animalRepository.GetUsersHaveAnimalsByUserId(userId)).Returns(userAnimalsForUser);

            // Mock the behavior of GetAllAnimalsByUserId method
            A.CallTo(() => animalRepository.GetAllAnimalsByUserId(userId)).Returns(resultAnimals);

            var handler = new GetAnimalsByUserIdQueryHandler(animalRepository);
            var query = new GetAnimalsByUserIdQuery(userId);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result, Is.InstanceOf<List<UserAnimalData>>());
            Assert.That(result.Count, Is.EqualTo(3));
            // Verify the specific items returned
            Assert.That(result[0].UserId, Is.EqualTo(resultAnimals[0].UserId));
            Assert.That(result[0].AnimalId, Is.EqualTo(resultAnimals[0].AnimalId));

        }
    }
}
