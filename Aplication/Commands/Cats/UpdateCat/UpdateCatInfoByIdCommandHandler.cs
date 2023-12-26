using Domain.Models.AnimalModel;
using Infrastructure.Database;
using Infrastructure.Repositories.Cats;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Commands.Cats.UpdateCat
{
    public class UpdateCatInfoByIdCommandHandler : IRequestHandler<UpdateCatInfoByIdCommand, Cat>
    {
        private readonly ICatRepository _catRepository;
        private readonly ILogger<UpdateCatInfoByIdCommandHandler> _logger;

        public UpdateCatInfoByIdCommandHandler(ICatRepository catRepository, ILogger<UpdateCatInfoByIdCommandHandler> logger)
        {
            _catRepository = catRepository;
            _logger = logger;
        }
        public async Task<Cat> Handle(UpdateCatInfoByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Cat catToUpdate = await _catRepository.GetCatById(request.Id);
                if (catToUpdate == null)
                {
                    _logger.LogWarning("Cat not found for update: {CatId}", request.Id);
                    throw new KeyNotFoundException($"Cat with ID {request.Id} was not found.");
                }
                catToUpdate.Name = request.UpdatedDtoCat.Name;
                catToUpdate.LikesToPlay = request.UpdatedDtoCat.LikesToPlay;
                catToUpdate.Breed = request.UpdatedDtoCat.Breed;
                catToUpdate.Weight = request.UpdatedDtoCat.Weight;

                var updatedCat = await _catRepository.UpdateCat(catToUpdate);
                _logger.LogInformation("Cat updated successfully: {CatId}", catToUpdate.AnimalId);
                return updatedCat;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating cat: {CatId}", request.Id);
                throw;
            }
        }
    }
}
