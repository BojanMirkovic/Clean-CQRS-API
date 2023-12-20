using Domain.Models.UserModel;

namespace Domain.Models.AnimalModel
{
    public class Animal
    {
        public Guid AnimalId { get; set; }
        public string Name { get; set; } = string.Empty;//umesto da pisemo =null, stirng.Empty

        public string AnimalType { get; set; } = string.Empty;

        public List<User> Users { get; set; } = new List<User>();
    };
}
