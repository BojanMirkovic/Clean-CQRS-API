using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Database;
using Domain.Models.Animal;

namespace Application.Queries.Dogs.GetDogById
{
    public class GetDogByIdQueryHandler : IRequestHandler<GetDogByIdQuery, Dog>
    {
        private readonly MockDatabase _mockDatabase;

        public GetDogByIdQueryHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }
        public Task<Dog> Handle(GetDogByIdQuery request, CancellationToken cancellationToken)
        {
            Dog wantedDog= _mockDatabase.Dogs.Where(Dog => Dog.Id == request.Id).FirstOrDefault()!;

            return Task.FromResult(wantedDog);
        }
    }
}
