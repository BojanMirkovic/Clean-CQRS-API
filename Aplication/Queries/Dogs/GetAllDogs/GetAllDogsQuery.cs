using Domain.Models.Animal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Dogs.GetAllDogs
{
    public class GetAllDogsQuery : IRequest<List<Dog>>//List<Dog> je ono sto ocekujemo da dobijemo kao odgovor iz DB
    {
    }
}
