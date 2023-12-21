using Application.Commands.Dogs.AddDog;
using Application.Dtos;
using Domain.Models.AnimalModel;
using FakeItEasy;
using Infrastructure.Repositories.Dogs;

namespace Test.DogTests.CommandTest
{
    [TestFixture]
    public class AddDogTest
    {
        [Test]
        public async Task Handle_Add_Dog_To_DB()
        {
            //Arrange
            var dog = new Dog { Name = "Boby", Breed = "Bulldog" };

            var dogRepository = A.Fake<IDogRepository>();

            var handler = new AddDogCommandHandler(dogRepository);

            A.CallTo(() => dogRepository.AddDog(dog)).Returns(dog);

            var dto = new DogDto();

            dto.Name = "Boby";
            dto.Breed = "Bulldog";
            dto.Weight = 25;

            var command = new AddDogCommand(dto);

            //Act
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.Name.Equals("Boby"));
            Assert.That(result, Is.TypeOf<Dog>());
        }
    }
}

