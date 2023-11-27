using Application.Dtos;
using Domain.Models.Animal;
using MediatR;

namespace Application.Commands.Birds.UpdateBird
{
    public class UpdateBirdInfoByIdCommand : IRequest<Bird>
    {
        public UpdateBirdInfoByIdCommand(BirdDto updatedBird, Guid id)
        {
            UpdatedBird = updatedBird;
            Id = id;
        }
        public BirdDto UpdatedBird { get; }
        public Guid Id { get; }

    }
}
