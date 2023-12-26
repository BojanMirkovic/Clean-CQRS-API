using Domain.Models.UserModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.AnimalModel
{
    public class Animal
    {
        [Key]
        public Guid AnimalId { get; set; }
        public string Name { get; set; } = string.Empty;//umesto da pisemo =null, stirng.Empty
        public string? AnimalType { get; set; }
        public Guid? UserId { get; set; }
    };
}
