
namespace Domain.Models.UserAnimalModel
{
    public class UsersHaveAnimals
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public Guid AnimalId { get; set; }
    }
}
