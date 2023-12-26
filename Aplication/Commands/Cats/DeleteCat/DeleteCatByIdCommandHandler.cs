using Domain.Models.AnimalModel;
using Infrastructure.Database;
using Infrastructure.Repositories.Cats;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Commands.Cats.DeleteCat
{
    public class DeleteCatByIdCommandHandler : IRequestHandler<DeleteCatByIdCommand, Cat>
    {
        private readonly ICatRepository _catRepository;
        private readonly ILogger<DeleteCatByIdCommandHandler> _logger;

        public DeleteCatByIdCommandHandler(ICatRepository catRepository, ILogger<DeleteCatByIdCommandHandler> logger)
        {
            _catRepository = catRepository;
            _logger = logger;
        }

        public async Task<Cat> Handle(DeleteCatByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Cat catToDelete = await _catRepository.GetCatById(request.Id);
                if (catToDelete == null)
                {
                    _logger.LogWarning("Cat not found for deletion: {CatId}", request.Id);
                    throw new KeyNotFoundException($"Cat with ID {request.Id} was not found.");
                }

                 await _catRepository.DeleteCat(request.Id);

                _logger.LogInformation("Cat deleted: {CatId}", request.Id);
                return catToDelete;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting cat: {CatId}", request.Id);
                throw;
            }
        }
    }
}
