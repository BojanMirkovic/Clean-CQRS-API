using Domain.Models.AnimalModel;
using MediatR;

namespace Application.Queries.Cats.GetAllCatsByBreedAndWeight
{
    public class GetCatsByBreedAndWeightQuery : IRequest<List<Cat>>
    {
        public int? Weight { get; }
        public string Breed { get; }

        public GetCatsByBreedAndWeightQuery(int? weight, string breed)
        {
            Weight = weight;
            Breed = breed;
        }
    }

}
