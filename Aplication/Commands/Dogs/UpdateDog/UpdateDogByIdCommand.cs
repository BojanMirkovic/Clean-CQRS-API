using Application.Dtos;
using Domain.Models.AnimalModel;
using MediatR;

namespace Application.Commands.Dogs.UpdateDog
{
    public class UpdateDogByIdCommand : IRequest<Dog>
    {
        public UpdateDogByIdCommand(DogDto updatedDog, Guid id)
        {
            UpdatedDtoDog = updatedDog;
            Id = id;
        }

        public DogDto UpdatedDtoDog { get; }
        public Guid Id { get; }
    }
}
