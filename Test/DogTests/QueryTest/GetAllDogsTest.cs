﻿using Application.Queries.Dogs.GetAllDogs;
using Application.Queries.Dogs.GetDogById;
using Domain.Models.Animal;
using Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DogTests.QueryTest
{
    [TestFixture]
    public class GetAllDogsTest
    {
        private GetAllDogsQueryHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _handler = new GetAllDogsQueryHandler(_mockDatabase);
        }
        [Test]
        public async Task Handle_GetAllDogsFromDB_ReturnsResultIsEqualToDB()
        {
            // Arrange
            var allDogsFromMockDB = _mockDatabase.Dogs;
            var query = new GetAllDogsQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.EqualTo(allDogsFromMockDB));
        }
    }
}