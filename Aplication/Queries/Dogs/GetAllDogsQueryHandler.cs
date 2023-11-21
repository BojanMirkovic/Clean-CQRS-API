using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Database;

namespace Application.Queries.Dogs
{
    internal class GetAllDogsQueryHandler : IRequestHandler<GetAllDogsQuery, List<Dog>>
    {
        private readonly MockDatabase _mockDatabase;

        public GetAllDogsQueryHandler(MockDatabase mockDatabase) 
        {
            _mockDatabase = mockDatabase;
        }
        public Task<List<Dog>> Handle(GetAllDogsQuery request, CancellationToken cancellationToken)
        {
            //
            List<Dog> allDogsFromMockDB = _mockDatabase.allDogs;
            return Task.FromResult(allDogsFromMockDB);
        }
    }
}
