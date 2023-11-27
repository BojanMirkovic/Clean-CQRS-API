using Domain.Models.Animal;
using MediatR;

namespace Application.Queries.Cats.GetCatById
{
    public class GetCatByIdQuery : IRequest<Cat>
    {
        public GetCatByIdQuery(Guid catId)
        {
            Id = catId;
        }

        public Guid Id { get; }
    }
}
