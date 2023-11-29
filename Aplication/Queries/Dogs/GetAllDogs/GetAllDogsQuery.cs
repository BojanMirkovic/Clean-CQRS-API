using Domain.Models.Animal;
using MediatR;

namespace Application.Queries.Dogs.GetAllDogs
{
    public class GetAllDogsQuery : IRequest<List<Dog>>//List<Dog> je ono sto ocekujemo da dobijemo kao odgovor iz DB
    {
    }
}
