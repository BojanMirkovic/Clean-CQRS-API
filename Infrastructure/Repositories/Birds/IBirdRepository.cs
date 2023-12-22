using Domain.Models.AnimalModel;

namespace Infrastructure.Repositories.Birds
{
    public interface IBirdRepository
    {
        Task<List<Bird>> GetAllBirds();
        Task<List<Bird>> GetAllBirdsOfSameColor(String color);
        Task<Bird> GetBirdById(Guid id);
        Task<Bird> AddBird(Bird newBird);
        Task<Bird> UpdateBird(Bird updateBird);
        Task<Bird> DeleteBird(Guid id);     
    }
}