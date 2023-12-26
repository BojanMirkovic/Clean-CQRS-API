using Domain.Models.AnimalModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Animals.GetAllAnimals
{
    public class GetAllAnimalsQuery : IRequest<List<Animal>>
    {
    }
}
