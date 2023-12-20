using Application.Dtos;
using Domain.Models.AnimalModel;
using MediatR;

namespace Application.Commands.Cats.UpdateCat
{
    public class UpdateCatInfoByIdCommand : IRequest<Cat>
    {
        public UpdateCatInfoByIdCommand(CatDto updatedCat, Guid id)
        {
            UpdatedDtoCat = updatedCat;
            Id = id;
        }

        public CatDto UpdatedDtoCat { get; }
        public Guid Id { get; }
    }
}
