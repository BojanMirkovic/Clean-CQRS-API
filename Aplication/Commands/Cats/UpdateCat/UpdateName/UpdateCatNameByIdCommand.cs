using Application.Dtos;
using Domain.Models.Animal;
using MediatR;

namespace Application.Commands.Cats.UpdateCat.UpdateName
{
    public class UpdateCatNameByIdCommand : IRequest<Cat>
    {
        public UpdateCatNameByIdCommand(CatDto updatedCat, Guid id)
        {
            UpdatedCat = updatedCat;
            Id = id;
        }

        public CatDto UpdatedCat { get; }
        public Guid Id { get; }
    }
}
