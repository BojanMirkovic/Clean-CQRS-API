using Domain.Models.AnimalModel;
using Infrastructure.Database;
using Infrastructure.Repositories.Birds;
using Infrastructure.Repositories.Cats;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Commands.Cats.AddCat
{
    public class AddCatCommandHandler : IRequestHandler<AddCatCommand, Cat>
    {
        private readonly ICatRepository _catRepository;
        private readonly ILogger<AddCatCommandHandler> _logger;

        public AddCatCommandHandler(ICatRepository catRepository, ILogger<AddCatCommandHandler> logger)
        {
            _catRepository = catRepository;
            _logger = logger;
        }
        public async Task<Cat> Handle(AddCatCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Cat catToCreate = new()
                {
                    AnimalId = new Guid(),
                    AnimalType = request.NewCat.AnimalType,
                    Name = request.NewCat.Name,
                    Breed = request.NewCat.Breed,
                    Weight = request.NewCat.Weight,
                    LikesToPlay = request.NewCat.LikesToPlay,
                };

                await _catRepository.AddCat(catToCreate);
                _logger.LogInformation($"New cat created: AnimalId = {catToCreate.AnimalId}, AnimalType = {catToCreate.AnimalType}, Name = {catToCreate.Name}," +
                                       $"Breed = {catToCreate.Breed}, Wight = {catToCreate.Weight}, LikesToPlay = {catToCreate.LikesToPlay}");
                return catToCreate;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating a new cat");
                throw;
            }
        }
    }
}
