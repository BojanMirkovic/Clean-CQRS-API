using Domain.Models.AnimalModel;
using Infrastructure.Database;
using Infrastructure.Repositories.Cats;
using MediatR;

namespace Application.Commands.Cats.UpdateCat
{
    public class UpdateCatInfoByIdCommandHandler : IRequestHandler<UpdateCatInfoByIdCommand, Cat>
    {
        private readonly ICatRepository _catRepository;

        public UpdateCatInfoByIdCommandHandler(ICatRepository catRepository)
        {
            _catRepository = catRepository;
        }
        public async Task<Cat> Handle(UpdateCatInfoByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Cat catToUpdate = await _catRepository.GetCatById(request.Id);
                if (catToUpdate == null)
                {
                    return null!;
                }
                catToUpdate.Name = request.UpdatedDtoCat.Name;
                catToUpdate.LikesToPlay = request.UpdatedDtoCat.LikesToPlay;
                catToUpdate.Breed = request.UpdatedDtoCat.Breed;
                catToUpdate.Weight = request.UpdatedDtoCat.Weight;

                var updatedCat = await _catRepository.UpdateCat(catToUpdate);
                return updatedCat;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
