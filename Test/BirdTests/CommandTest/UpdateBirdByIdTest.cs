using Application.Commands.Birds.UpdateBird;
using Application.Dtos;
using Domain.Models.AnimalModel;
using FakeItEasy;
using Infrastructure.Repositories.Birds;

namespace Test.BirdTests.CommandTest
{
    [TestFixture]
    public class UpdateBirdByIdTest
    {
        [Test]
        public async Task Handle_Update_Correct_Bird_By_Id()
        {
            //Arrange

            var guid = new Guid("ce9b91e4-08d1-4628-82c1-8ef6ec623230");

            var bird = new Bird
            {
                AnimalId = new Guid("ce9b91e4-08d1-4628-82c1-8ef6ec623230"),
                Name = "Ara",
                Color = "Blue",
                CanFly = false,
            };

            var birdDto = new BirdDto { Name = "Ara", Color="Red", CanFly=true  };

            var birdRepository = A.Fake<IBirdRepository>();

            var handler = new UpdateBirdInfoByIdCommandHandler(birdRepository);

            A.CallTo(() => birdRepository.GetBirdById(bird.AnimalId)).Returns(bird);

            A.CallTo(() => birdRepository.UpdateBird(bird)).Returns(bird);

            var command = new UpdateBirdInfoByIdCommand(birdDto, guid);

            //Act

            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.Name.Equals("Ara"));
            Assert.That(result.Color.Equals("Red"));
            Assert.That(result.CanFly.Equals(true));
            Assert.That(result, Is.TypeOf<Bird>());
        }
    }
}

