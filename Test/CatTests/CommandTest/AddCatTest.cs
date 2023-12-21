using Application.Commands.Cats.AddCat;
using Application.Dtos;
using Domain.Models.AnimalModel;
using FakeItEasy;
using Infrastructure.Database;
using Infrastructure.Repositories.Cats;

namespace Test.CatTests.CommandTest
{
    [TestFixture]
    public class AddCatTest
    {
        [Test]
        public async Task Handle_Add_Cat_To_Database()
        {
            //Arrange
            var cat = new Cat { AnimalId = new Guid(), Name = "Herman", Breed = "Domestic Cat", Weight = 4, LikesToPlay = true };
            var requestGuid = Guid.NewGuid();

            var catRepository = A.Fake<ICatRepository>();

            var handler = new AddCatCommandHandler(catRepository);

            A.CallTo(() => catRepository.AddCat(cat)).Returns(cat);

            var dto = new CatDto();

            dto.Name = "Herman";
            dto.Breed = "Huskatt";
            dto.Weight = 4;
            dto.LikesToPlay = true;

            var command = new AddCatCommand(dto);

            //Act

            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.Name.Equals("Herman"));
            Assert.That(result, Is.TypeOf<Cat>());
        }
    }
}

