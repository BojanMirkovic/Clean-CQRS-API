using Application.Dtos;
using Domain.Models.AnimalModel;
using MediatR;

namespace Application.Commands.Birds.UpdateBird
{
    public class UpdateBirdInfoByIdCommand : IRequest<Bird>
    {
        public UpdateBirdInfoByIdCommand(BirdDto updatedBird, Guid id)
        {
            UpdatedDtoBird = updatedBird;
            Id = id;
        }
        public BirdDto UpdatedDtoBird { get; }
        public Guid Id { get; }

    }
}
