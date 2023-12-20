using Domain.Models.AnimalModel;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Dogs.DeleteDog
{
    public class DeleteDogByIdCommandHandler : IRequestHandler<DeleteDogByIdCommand, Dog>
    {
        MockDatabase _mockDatabase;
        public DeleteDogByIdCommandHandler(MockDatabase mockDatabase)
        { _mockDatabase = mockDatabase; }
        public Task<Dog> Handle(DeleteDogByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Dog? dogToDelete = _mockDatabase.Dogs.FirstOrDefault(dog => dog.AnimalId == request.Id)!;
                if (dogToDelete != null)
                {
                    _mockDatabase.Dogs.Remove(dogToDelete);
                    return Task.FromResult(dogToDelete)!;
                }
                return Task.FromResult<Dog>(null!);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
