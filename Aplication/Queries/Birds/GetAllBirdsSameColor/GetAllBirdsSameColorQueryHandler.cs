using Application.Dtos;
using Domain.Models.AnimalModel;
using Infrastructure.Repositories.Birds;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Birds.GetAllBirdsSameColor
{
    public class GetAllBirdsSameColorQueryHandler : IRequestHandler<GetAllBirdsSameColorQuery, List<Bird>>
    {
        private readonly IBirdRepository _birdRepository;

        public GetAllBirdsSameColorQueryHandler(IBirdRepository birdRepository)
        {
            _birdRepository = birdRepository;
        }
        public async Task<List<Bird>> Handle(GetAllBirdsSameColorQuery request, CancellationToken cancellationToken)
        {
            List<Bird> allBirdsOfSameColorFromDB = await _birdRepository.GetAllBirdsOfSameColor(request.BirdColor);

            return allBirdsOfSameColorFromDB; 
        }
    }
}
