using Application.Dtos;
using Application.Queries.Birds.GetAllBirds;
using Application.Queries.Birds.GetAllBirdsSameColor;
using Domain.Models.AnimalModel;
using FakeItEasy;
using Infrastructure.Repositories.Birds;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.BirdTests.QueryTest
{
    [TestFixture]
    public class GetAllBirdsOfSameColorTest
    {
        [Test]
        public async Task GetAllBirdsOfSameColor_ShouldReturnBirds_WhenColorExists()
        {
            // Arrange
            var color = "Red";
            var fakeBirdsData = new List<Bird>
        {
            new Bird { AnimalId = Guid.NewGuid(), Name = "Bluebird", Color = "Blue", CanFly = true },
            new Bird { AnimalId = Guid.NewGuid(), Name = "Robin", Color = "Red", CanFly = true },
            new Bird { AnimalId = Guid.NewGuid(), Name = "Mike", Color = "Red", CanFly = true },
        };

            var birdRepository = A.Fake<IBirdRepository>();
            var handler = new GetAllBirdsSameColorQueryHandler(birdRepository);

            A.CallTo(() => birdRepository.GetAllBirdsOfSameColor(color)).Returns(
                fakeBirdsData.Where(b => b.Color == color).ToList()
            );

            var query = new GetAllBirdsSameColorQuery(color);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<List<Bird>>(result);
            Assert.That(result.Count, Is.EqualTo(2)); // Ensure the correct count based on the filter
        }
    }
}