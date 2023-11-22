using Application.Dtos;
using Domain.Models.Animal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Dogs.UpdateDog
{
    public class UpdateDogByIdCommand : IRequest<Dog>
    {
        public UpdateDogByIdCommand(DogDto updatedDog, Guid id)
        {
            UpdatedDog = updatedDog;
            Id = id;
        }

        public DogDto UpdatedDog { get; }
        public Guid Id { get; }
    }
}
