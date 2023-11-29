﻿using Domain.Models.Animal;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Birds.AddBird
{
    public class AddBirdCommandHandler : IRequestHandler<AddBirdCommand, Bird>
    {
        private readonly MockDatabase _mockDatabase;

        public AddBirdCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }
        public Task<Bird> Handle(AddBirdCommand request, CancellationToken cancellationToken)
        {
            Bird birdToCreate = new()
            {
                Id = new Guid(),
                Name = request.NewBird.Name,
                CanFly = request.NewBird.CanFly,
            };

            _mockDatabase.Birds.Add(birdToCreate);
            return Task.FromResult(birdToCreate);
        }
    }
}
