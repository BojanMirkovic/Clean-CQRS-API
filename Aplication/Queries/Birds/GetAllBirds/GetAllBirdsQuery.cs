using Domain.Models.Animal;
using MediatR;

namespace Application.Queries.Birds.GetAllBirds
{
    public class GetAllBirdsQuery : IRequest<List<Bird>>
    {
    }
}
