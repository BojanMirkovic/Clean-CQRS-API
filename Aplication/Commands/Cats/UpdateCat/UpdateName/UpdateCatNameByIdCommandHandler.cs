using Domain.Models.Animal;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Cats.UpdateCat.UpdateName
{
    public class UpdateCatNameByIdCommandHandler : IRequestHandler<UpdateCatNameByIdCommand, Cat>
    {
        private readonly MockDatabase _mockDatabase;

        public UpdateCatNameByIdCommandHandler(MockDatabase mockDatabase)
        { _mockDatabase = mockDatabase; }
        public Task<Cat> Handle(UpdateCatNameByIdCommand request, CancellationToken cancellationToken)
        {
            Cat catToUpdate = _mockDatabase.Cats.FirstOrDefault(cat => cat.Id == request.Id)!;

            catToUpdate.Name = request.UpdatedCat.Name;

            return Task.FromResult(catToUpdate);
        }
    }
}
