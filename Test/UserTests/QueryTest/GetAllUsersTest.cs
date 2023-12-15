using Application.Queries.Users.GetAllUsers;
using Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.UserTests.QueryTest
{
    [TestFixture]
    public class GetAllUsersTest
    {
        private GetAllUsersQueryHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _handler = new GetAllUsersQueryHandler(_mockDatabase);
        }
        [Test]
        public async Task Handle_GetAllUsersFromDB_ReturnsResultIsEqualToUsersDB()
        {
            // Arrange
            var allUsersFromMockDB = _mockDatabase.Users;
            var query = new GetAllUsersQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.EqualTo(allUsersFromMockDB));
        }
        [Test]
        public async Task Handle_EmptyDB_ReturnsNull()
        {
            // Arrange
            _mockDatabase.Users = null!;

            var query = new GetAllUsersQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsNull(result);
        }
    }
}
