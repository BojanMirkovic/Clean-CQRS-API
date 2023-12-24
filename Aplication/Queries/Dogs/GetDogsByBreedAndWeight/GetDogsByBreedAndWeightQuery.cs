using Domain.Models.AnimalModel;
using MediatR;

namespace Application.Queries.Dogs.GetCatsByBreedAndWeight
{
    public class GetDogsByBreedAndWeightQuery : IRequest<List<Dog>>
    {
        public int? Weight { get; }
        public string Breed { get; }
        public GetDogsByBreedAndWeightQuery(int? weight, string breed)
        {
            Weight = weight;
            Breed = breed;
        }
    }
}
