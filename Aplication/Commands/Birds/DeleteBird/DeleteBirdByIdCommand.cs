using Domain.Models.AnimalModel;
using MediatR;

namespace Application.Commands.Birds.DeleteBird
{
    public class DeleteBirdByIdCommand : IRequest<Bird>
    {
        public DeleteBirdByIdCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; }
    }
}
