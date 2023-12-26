using Domain.Models.AnimalModel;
using MediatR;

namespace Application.Queries.Animals.GetAnimalById
{
    public class GetAnimalByIdQuery : IRequest<Animal>
    {
        public Guid Id { get; set; }
        public GetAnimalByIdQuery(Guid animalId)
        {
            Id = animalId;
        }
    }
}
