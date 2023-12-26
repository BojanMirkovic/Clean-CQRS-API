using Application.Commands.Birds.AddBird;
using Application.Dtos;
using Domain.Models.AnimalModel;
using FakeItEasy;
using Infrastructure.Repositories.Birds;

namespace Test.BirdTests.CommandTest
{
    [TestFixture]
    public class AddBirdTest
    {

        [Test]
        public async Task Handle_AddNewBirdToDB_ResultDB_HasNewElement()
        {
            //Arrange
            var bird = new Bird { Name = "Micko", Color = "blue", CanFly = true };

            var birdRepository = A.Fake<IBirdRepository>();

            var handler = new AddBirdCommandHandler(birdRepository);

            A.CallTo(() => birdRepository.AddBird(bird)).Returns(bird);

            var dto = new BirdDto();

            dto.Name = "Micko";
            dto.Color = "Blue";
            dto.CanFly = true;



            var command = new AddBirdCommand(dto);

            //Act
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.Name.Equals("Micko"));
            Assert.That(result, Is.TypeOf<Bird>());
        }
    }
}

