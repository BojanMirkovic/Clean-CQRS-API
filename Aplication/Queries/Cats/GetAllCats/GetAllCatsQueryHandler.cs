using Domain.Models.Animal;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Cats.GetAllCats
{
    public class GetAllCatsQueryHandler : IRequestHandler<GetAllCatsQuery, List<Cat>>
    {
        private readonly MockDatabase _mockDatabase;
        public GetAllCatsQueryHandler(MockDatabase mockDatabase) 
        {
            _mockDatabase = mockDatabase;
        }
        public Task<List<Cat>> Handle(GetAllCatsQuery request, CancellationToken cancellationToken)
        {
            List<Cat> allCatsFromMockDB = _mockDatabase.Cats;
            return Task.FromResult(allCatsFromMockDB);
        }
    }
}
