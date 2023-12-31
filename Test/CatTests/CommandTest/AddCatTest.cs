﻿using Application.Commands.Cats.AddCat;
using Application.Dtos;
using Domain.Models.AnimalModel;
using FakeItEasy;
using Infrastructure.Repositories.Cats;
using Microsoft.Extensions.Logging.Abstractions;

namespace Test.CatTests.CommandTest
{
    [TestFixture]
    public class AddCatTest
    {
        [Test]
        public async Task Handle_Add_Cat_To_Database()
        {
            // Arrange
            var cat = new Cat { AnimalId = Guid.NewGuid(), Name = "Herman", Breed = "Domestic Cat", Weight = 4, LikesToPlay = true };

            var catRepository = A.Fake<ICatRepository>();
            A.CallTo(() => catRepository.AddCat(A<Cat>._)).Returns(cat);

            var logger = new NullLogger<AddCatCommandHandler>(); // Using NullLogger from Microsoft.Extensions.Logging.Abstractions

            var handler = new AddCatCommandHandler(catRepository, logger);

            var dto = new CatDto
            {
                Name = "Herman",
                Breed = "Huskatt",
                Weight = 4,
                LikesToPlay = true
            };

            var command = new AddCatCommand(dto);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Name.Equals("Herman"));
            Assert.That(result, Is.TypeOf<Cat>());
        }
    }
}

