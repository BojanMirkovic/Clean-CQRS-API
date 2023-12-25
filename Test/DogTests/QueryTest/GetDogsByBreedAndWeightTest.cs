using Application.Queries.Dogs.GetCatsByBreedAndWeight;
using Application.Queries.Dogs.GetDogsByBreedAndWeight;
using Domain.Models.AnimalModel;
using FakeItEasy;
using Infrastructure.Repositories.Dogs;


namespace Test.DogTests.QueryTest
{
    public class GetDogsByBreedAndWeightTest
    {
        [Test]
        public async Task Handle_Returns_Dogs_By_Breed_And_Weight()
        {
            // Arrange
            var fakeDogsData = new List<Dog>
            {
                new Dog { Name = "Rex", Breed = "English Pointer", Weight = 25 },
                new Dog { Name = "Ari", Breed = "English Pointer", Weight = 25 },
                new Dog { Name = "Astor", Breed = "English Pointer", Weight = 35 },
                new Dog { Name = "Buster", Breed = "English Pointer", Weight = 22 },
                new Dog { Name = "Tom", Breed = "Bulldog", Weight = 27 },
                new Dog { Name = "Felix", Breed = "Bulldog", Weight = 19 },
            };

            var dogRepository = A.Fake<IDogRepository>();
            var handler = new GetDogsByBreedAndWeightQueryHandler(dogRepository);
            var request = new GetDogsByBreedAndWeightQuery(25, "English Pointer");

            A.CallTo(() => dogRepository.GetDogsByBreedAndWeight(A<string>._, A<int?>._)).Returns(
               fakeDogsData.Where(b => b.Weight >= 25).Where(c => c.Breed == "English Pointer").ToList()
           );

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Count, Is.EqualTo(3)); // Check if 3 dogs are returned for the specified breed and weight
            Assert.IsInstanceOf<List<Dog>>(result);
        }

        [Test]
        public async Task Handle_Returns_Empty_List_When_No_Dogs_Found()
        {
            // Arrange
            var dogRepository = A.Fake<IDogRepository>();
            var handler = new GetDogsByBreedAndWeightQueryHandler(dogRepository);
            var request = new GetDogsByBreedAndWeightQuery(25, "English Pointer");

            A.CallTo(() => dogRepository.GetDogsByBreedAndWeight(A<string>._, A<int?>._))
                .Returns(new List<Dog>());

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Count, Is.EqualTo(0)); // Ensure an empty list is returned when no dogs are found
        }
    }
}
