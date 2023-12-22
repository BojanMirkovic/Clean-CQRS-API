using Domain.Models.UserModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.AnimalModel
{
    public abstract class Animal
    {
        [Key]
        public Guid AnimalId { get; set; }
        public string Name { get; set; } = string.Empty;//umesto da pisemo =null, stirng.Empty

    };
}
