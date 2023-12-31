using Application.Commands.Cats.DeleteCat;
using Application.Queries.Cats.GetAllCatsByBreedAndWeight;
using Domain.Models.AnimalModel;
using FakeItEasy;
using Infrastructure.Repositories.Birds;
using Infrastructure.Repositories.Cats;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.CatTests.QueryTest
{
    [TestFixture]
    public class GetCatsByBreedAndWeightTest
    {
        [Test]
        public async Task Handle_Returns_Cats_By_Breed_And_Weight()
        {
            // Arrange
            var fakeCatsData = new List<Cat>
            {
                new Cat { Name = "Fluffy", Breed = "Persian", Weight = 5 },
                new Cat { Name = "Whiskers", Breed = "Persian", Weight = 5 },
                new Cat { Name = "Silvester", Breed = "Persian", Weight = 3 },
                new Cat { Name = "Mika", Breed = "Persian", Weight = 7 },
                new Cat { Name = "Tom", Breed = "Domestic Cat", Weight = 7 },
                new Cat { Name = "Felix", Breed = "Domestic Cat", Weight = 9 },
            };

            var catRepository = A.Fake<ICatRepository>();

            var logger = new NullLogger<GetCatsByBreedAndWeightQueryHandler>();
            var handler = new GetCatsByBreedAndWeightQueryHandler(catRepository, logger);
            var request = new GetCatsByBreedAndWeightQuery(5, "Persian");

            var catsToReturn = new List<Cat>
            {
                new Cat { Name = "Fluffy", Breed = "Persian", Weight = 5 },
                new Cat { Name = "Whiskers", Breed = "Persian", Weight = 6 },
            };

            //A.CallTo(() => catRepository.GetCatsByBreedAndWeight(A<string>._, A<int?>._))
            //.Returns(catsToReturn);
            A.CallTo(() => catRepository.GetCatsByBreedAndWeight(A<string>._, A<int?>._)).Returns(
               fakeCatsData.Where(b => b.Weight >= 5).Where(c => c.Breed == "Persian").ToList()
           );

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Count, Is.EqualTo(3)); // Check if 2 cats are returned for the specified breed and weight
            Assert.IsInstanceOf<List<Cat>>(result);
            // Add more assertions to verify the correctness of the returned cats
        }

        [Test]
        public async Task Handle_Returns_Empty_List_When_No_Cats_Found()
        {
            // Arrange
            var fakeCatRepository = A.Fake<ICatRepository>();

            var logger = new NullLogger<GetCatsByBreedAndWeightQueryHandler>();
            var handler = new GetCatsByBreedAndWeightQueryHandler(fakeCatRepository, logger);
            var request = new GetCatsByBreedAndWeightQuery(5, "Persian");

            A.CallTo(() => fakeCatRepository.GetCatsByBreedAndWeight(A<string>._, A<int?>._))
                .Returns(new List<Cat>());

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Count, Is.EqualTo(0)); // Ensure an empty list is returned when no cats are found

        }
    }
}

