using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.UserAnimalModel
{
    public class UserAnimalData
    {
        public Guid UserId { get; set; }
        public Guid AnimalId { get; set; }
        public string? AnimalName { get; set; }
        public string? AnimalType { get; set; }
    }
}
