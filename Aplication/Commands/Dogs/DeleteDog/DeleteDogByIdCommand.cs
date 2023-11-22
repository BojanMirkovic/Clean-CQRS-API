using Application.Dtos;
using Domain.Models.Animal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Dogs.DeleteDog
{
    public class DeleteDogByIdCommand : IRequest<Dog>
    {
        public DeleteDogByIdCommand(DogDto dogToDelete, Guid id)
        {
           DogToDelete = dogToDelete;
           Id = id;
        }
            public DogDto DogToDelete { get; }
            public Guid Id { get; }      
    }
}
