using Application.Commands.Animals.AddUserAnimalConnection;
using Domain.Models.UserAnimalModel;
using FakeItEasy;
using Infrastructure.Repositories.Animals;

namespace Test.AnimalTests.CommandTest
{
    public class AddUserAnimalConnectionTest
    {
        [Test]
        public async Task Handle_AddConnection_Success()
        {
            // Arrange
            var fakeAnimalRepository = A.Fake<IAnimalRepository>();
            var commandHandler = new AddUsersHaveAnimalsConnectionCommandHandler(fakeAnimalRepository);

            var userId = Guid.NewGuid();
            var animalId = Guid.NewGuid();
            var expectedConnection = new UsersHaveAnimals
            {
                UserId = userId,
                AnimalId = animalId
            };

            A.CallTo(() => fakeAnimalRepository.AddConnection(userId, animalId))
                .Returns(expectedConnection);

            var command = new AddUsersHaveAnimalsConnectionCommand(userId, animalId);

            // Act
            var result = await commandHandler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.EqualTo(expectedConnection));
            A.CallTo(() => fakeAnimalRepository.AddConnection(userId, animalId)).MustHaveHappenedOnceExactly();
        }

    }
}
