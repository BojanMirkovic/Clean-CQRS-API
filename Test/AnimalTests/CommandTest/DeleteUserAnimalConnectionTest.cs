using Application.Commands.Animals.DeleteUserAnimalConnection;
using Domain.Models.UserAnimalModel;
using FakeItEasy;
using Infrastructure.Repositories.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.AnimalTests.CommandTest
{
    public class DeleteUserAnimalConnectionTest
    {
        [Test]
        public async Task Handle_DeleteConnection_Success()
        {
            // Arrange
            var animalRepository = A.Fake<IAnimalRepository>();
            var commandHandler = new DeleteUserAnimalConnectionCommandHandler(animalRepository);

            var userId = new Guid("08260479-52a0-4c0e-a588-274101a2c3be");
            var animalId = new Guid("12345678-1234-5678-1234-567812345682");

            var expectedConnection = new UsersHaveAnimals
            {
                UserId = new Guid("08260479-52a0-4c0e-a588-274101a2c3be"),
                AnimalId = new Guid("12345678-1234-5678-1234-567812345682")
            };

            A.CallTo(() => animalRepository.DeleteConnection(userId, animalId))
                .Returns(expectedConnection);

            var command = new DeleteUserAnimalConnectionCommand(userId, animalId);

            // Act
            var result = await commandHandler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.EqualTo(expectedConnection));
            A.CallTo(() => animalRepository.DeleteConnection(userId, animalId)).MustHaveHappenedOnceExactly();
        }

    }
}
