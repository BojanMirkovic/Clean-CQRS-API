using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Animal;

namespace Application.Queries.Dogs.GetDogById
{
    public class GetDogByIdQuery: IRequest<Dog>
    {
        public GetDogByIdQuery(Guid dogId)
        {
            Id=dogId;
        }
        public Guid Id { get; }
    }
}
