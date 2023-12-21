using Application.Queries.Cats.GetCatById;
using Domain.Models.AnimalModel;
using FakeItEasy;
using Infrastructure.Repositories.Cats;

namespace Test.CatTests.QueryTest
{
    [TestFixture]
    public class GetCatByIdTests
    {
        [Test]
        public async Task Handle_ValidId_ReturnCorrectCat()
        {
            var guid = Guid.NewGuid();

            var cat = new Cat { Name = "Hans", Breed = "Domestic Cat" };

            var catRepository = A.Fake<ICatRepository>();

            var handler = new GetCatByIdQueryHandler(catRepository);

            A.CallTo(() => catRepository.GetCatById(guid)).Returns(cat);

            var command = new GetCatByIdQuery(guid);

            //Act

            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result, Is.TypeOf<Cat>());
            Assert.That(result.Name.Equals("Hans"));
        }
    }
}
