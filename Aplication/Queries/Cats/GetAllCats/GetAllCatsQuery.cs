using Domain.Models.AnimalModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Cats.GetAllCats
{
    public class GetAllCatsQuery : IRequest<List<Cat>>
    {
    }
}
