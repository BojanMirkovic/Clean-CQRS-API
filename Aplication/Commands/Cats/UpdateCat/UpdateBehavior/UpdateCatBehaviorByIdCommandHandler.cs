using Domain.Models.Animal;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Cats.UpdateCat.UpdateBehavior
{
    public class UpdateCatBehaviorByIdCommandHandler : IRequestHandler<UpdateCatBehaviorByIdCommand, Cat>
    {
        private readonly MockDatabase _mockDatabase;

        public UpdateCatBehaviorByIdCommandHandler(MockDatabase mockDatabase)
        { _mockDatabase = mockDatabase; }
        public Task<Cat> Handle(UpdateCatBehaviorByIdCommand request, CancellationToken cancellationToken)
        {
            Cat catToUpdate = _mockDatabase.Cats.FirstOrDefault(cat => cat.Id == request.Id)!;

            catToUpdate.LikesToPlay = request.UpdatedCat.LikesToPlay;

            return Task.FromResult(catToUpdate);
        }
    }
}

