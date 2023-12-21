using Application.Commands.Birds.DeleteBird;
using Domain.Models.AnimalModel;
using FakeItEasy;
using Infrastructure.Repositories.Birds;


namespace Test.BirdTests.CommandTest
{
    [TestFixture]
    public class DeleteBirdByIdTest
    {
        [Test]
        public async Task Handle_DeleteBird_Corect_Id()
        {
            //Arrange
            var bird = new Bird
            {
                AnimalId = Guid.NewGuid(),
                Name = "Hawk",
                Color ="Red",
                CanFly = true,    
            };

            var birdRepository = A.Fake<IBirdRepository>();

            var handler = new DeleteBirdByIdCommandHandler(birdRepository);

            A.CallTo(() => birdRepository.DeleteBird(bird.AnimalId)).Returns(bird);

            var command = new DeleteBirdByIdCommand(bird.AnimalId);

            //Act
            var result = await handler.Handle(command, CancellationToken.None);
           
            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.Name.Equals("Hawk"));
            Assert.That(result, Is.TypeOf<Bird>());
            Assert.That(result.AnimalId.Equals(bird.AnimalId));
            A.CallTo(() => birdRepository.DeleteBird(bird.AnimalId)).MustHaveHappened(); // Verify that DeleteBird method was called with the correct ID
        }
    }
}

