using Application.Dtos;
using Domain.Models.Animal;
using MediatR;

namespace Application.Commands.Birds.AddBird
{
    public class AddBirdCommand : IRequest<Bird>
    {
        public AddBirdCommand(BirdDto newBird)
        {
            NewBird = newBird;
        }
        public BirdDto NewBird { get; }
    }
}
