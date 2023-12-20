using Domain.Models.UserModel;
using Infrastructure.Database;
using MediatR;

namespace Application.Queries.Users.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<User>>
    {
        private readonly MockDatabase _mockDatabase;
        public GetAllUsersQueryHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {

            try
            {
                List<User>? allUsersFromMockDB = _mockDatabase.Users;
                return Task.FromResult(allUsersFromMockDB);
            }
            catch (NullReferenceException ex)
            {
                // Handle specific exception for null reference (if necessary)
                throw new ApplicationException("Database reference is null.", ex);
            }
            catch (Exception ex)
            {

                // Log the exception or handle it according to your application's needs
                throw new ApplicationException("Failed to fetch all users.", ex);
            }
        }
    }
}

