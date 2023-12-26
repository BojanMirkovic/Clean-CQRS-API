using Application.Queries.Animals.GetAnimalById;
using Application.Queries.Birds.GetBirdById;
using Domain.Models.AnimalModel;
using FakeItEasy;
using Infrastructure.Repositories.Animals;
using Infrastructure.Repositories.Birds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.AnimalTests.QueryTest
{
    public class GetAnimalByIdTest
    {

        [Test]
        public async Task Handle_ValidId_ReturnCorrectAnimal()
        {
            var guid = Guid.NewGuid();

            var animal = new Animal { Name = "Vrabac", AnimalType = "Bird" };

            var animalRepository = A.Fake<IAnimalRepository>();

            var handler = new GetAnimalByIdQueryHandler(animalRepository);

            A.CallTo(() => animalRepository.GetAnimalById(guid)).Returns(animal);

            var command = new GetAnimalByIdQuery(guid);

            //Act
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result, Is.TypeOf<Animal>());
            Assert.That(result.Name.Equals("Vrabac"));
            Assert.That(result.AnimalType, Is.EqualTo("Bird"));

        }
    }
}
