using Domain.Models.AnimalModel;
using MediatR;

namespace Application.Queries.Birds.GetBirdById
{
    public class GetBirdByIdQuery : IRequest<Bird>
    {
        public GetBirdByIdQuery(Guid birdId)
        {
            Id = birdId;
        }
        public Guid Id { get; }
    }
}
