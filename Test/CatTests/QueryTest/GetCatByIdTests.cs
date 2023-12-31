using Application.Commands.Cats.DeleteCat;
using Application.Queries.Cats.GetCatById;
using Domain.Models.AnimalModel;
using FakeItEasy;
using Infrastructure.Repositories.Cats;
using Microsoft.Extensions.Logging.Abstractions;
using Nest;
using System;

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
            var logger = new NullLogger<GetCatByIdQueryHandler>();
            var handler = new GetCatByIdQueryHandler(catRepository, logger);

            A.CallTo(() => catRepository.GetCatById(guid)).Returns(cat);

            var command = new GetCatByIdQuery(guid);

            //Act

            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result, Is.TypeOf<Cat>());
            Assert.That(result.Name.Equals("Hans"));
        }

        [Test]
        public void Handle_InvalidId_ThrowsKeyNotFoundException()
        {
            // Arrange
            var incorrectCatId = Guid.NewGuid(); // An incorrect ID that doesn't exist in the repository

            Cat cat = null; // Set cat as null to simulate not found scenario

            var catRepository = A.Fake<ICatRepository>();

            var logger = new NullLogger<GetCatByIdQueryHandler>();
            var handler = new GetCatByIdQueryHandler(catRepository, logger);

            A.CallTo(() => catRepository.GetCatById(incorrectCatId)).Returns(cat!); // Simulate repository returning null for an incorrect ID

            // Act
            var command = new GetCatByIdQuery(incorrectCatId);
            var exception = Assert.ThrowsAsync<KeyNotFoundException>(async () => await handler.Handle(command, CancellationToken.None));
            var expectedMessage = $"Cat with ID {incorrectCatId} was not found."; // Ensure the exact expected message

            // Assert
            Assert.That(exception.Message, Is.EqualTo(expectedMessage));
        }
    }
}

