using Application.Commands.Cats.UpdateCat;
using Application.Dtos;
using Domain.Models.AnimalModel;
using FakeItEasy;
using Infrastructure.Database;
using Infrastructure.Repositories.Cats;

namespace Test.CatTests.CommandTest
{
    [TestFixture]
    internal class UpdateCatByIdTest
    {

        [Test]
        public async Task Handle_Update_Correct_Cat_By_Id()
        {
            //Arrange

            var guid = new Guid("ce9b91e4-08d1-4628-82c1-8ef6ec622220");

            var cat = new Cat 
            { 
                AnimalId = new Guid("ce9b91e4-08d1-4628-82c1-8ef6ec622220"), 
                Name = "Tom", 
                Breed = "Domestic Cat",
                LikesToPlay = true 
            };

            var catDto = new CatDto { Name = "Mika", LikesToPlay = true };

            var catRepository = A.Fake<ICatRepository>();

            var handler = new UpdateCatInfoByIdCommandHandler(catRepository);

            A.CallTo(() => catRepository.GetCatById(cat.AnimalId)).Returns(cat);

            A.CallTo(() => catRepository.UpdateCat(cat)).Returns(cat);

            var command = new UpdateCatInfoByIdCommand(catDto, guid);

            //Act

            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.Name.Equals("Mika"));
            Assert.That(result.LikesToPlay.Equals(true));
            Assert.That(result, Is.TypeOf<Cat>());
        }
    }
}

