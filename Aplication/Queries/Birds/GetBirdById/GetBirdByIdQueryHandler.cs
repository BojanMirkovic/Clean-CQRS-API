﻿using Domain.Models.AnimalModel;
using Infrastructure.Database;
using Infrastructure.Repositories.Birds;
using MediatR;

namespace Application.Queries.Birds.GetBirdById
{
    public class GetBirdByIdQueryHandler : IRequestHandler<GetBirdByIdQuery, Bird>
    {
        private readonly IBirdRepository _birdRepository;

        public GetBirdByIdQueryHandler(IBirdRepository birdRepository)
        {
            _birdRepository = birdRepository;
        }

        public async Task<Bird> Handle(GetBirdByIdQuery request, CancellationToken cancellationToken)
        {

            Bird wantedBird = await _birdRepository.GetBirdById(request.Id);
            if (wantedBird == null)
            {
                return null!;
            }

            return wantedBird;
        }
    }
}
