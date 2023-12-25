using Domain.Models.AnimalModel;
using Infrastructure.Database;
using Infrastructure.Repositories.Birds;
using Infrastructure.Repositories.Cats;
using MediatR;

namespace Application.Commands.Cats.AddCat
{
    public class AddCatCommandHandler : IRequestHandler<AddCatCommand, Cat>
    {
        private readonly ICatRepository _catRepository;

        public AddCatCommandHandler(ICatRepository catRepository)
        {
            _catRepository = catRepository;
        }
        public async Task<Cat> Handle(AddCatCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Cat catToCreate = new()
                {
                    AnimalId = new Guid(),
                    Name = request.NewCat.Name,
                    Breed = request.NewCat.Breed,
                    Weight = request.NewCat.Weight,
                    LikesToPlay = request.NewCat.LikesToPlay,
                };

                await _catRepository.AddCat(catToCreate);
                return catToCreate;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
