using Application.Dtos;
using Domain.Models.Animal;
using MediatR;

namespace Application.Commands.Cats.UpdateCat.UpdateBehavior
{
    public class UpdateCatBehaviorByIdCommand : IRequest<Cat>
    {
        public UpdateCatBehaviorByIdCommand(CatDto updatedCat, Guid id)
        {
            UpdatedCat = updatedCat;
            Id = id;
        }

        public CatDto UpdatedCat { get; }
        public Guid Id { get; }
    }
}
