using Domain.Models.Animal;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Cats.DeleteCat
{
    public class DeleteCatByIdCommandHandler : IRequestHandler<DeleteCatByIdCommand, Cat>
    {
        MockDatabase _mockDatabase;
        public DeleteCatByIdCommandHandler(MockDatabase mockDatabase)
        { _mockDatabase = mockDatabase; }
        public Task<Cat> Handle(DeleteCatByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Cat? catToDelete = _mockDatabase.Cats.FirstOrDefault(cat => cat.Id == request.Id)!;
                if (catToDelete != null)
                {
                    _mockDatabase.Cats.Remove(catToDelete);
                    return Task.FromResult(catToDelete)!;
                }

                return Task.FromResult<Cat>(null!);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
