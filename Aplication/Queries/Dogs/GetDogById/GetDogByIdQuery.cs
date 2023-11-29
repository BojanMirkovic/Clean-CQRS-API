using MediatR;
using Domain.Models.Animal;

namespace Application.Queries.Dogs.GetDogById
{
    public class GetDogByIdQuery : IRequest<Dog>
    {
        public GetDogByIdQuery(Guid dogId)
        {
            Id = dogId;
        }
        public Guid Id { get; }
    }
}
