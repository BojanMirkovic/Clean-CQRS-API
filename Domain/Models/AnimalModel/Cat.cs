using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.AnimalModel
{
    public class Cat : Animal
    {
        public required string Breed { get; set; }
        public int Weight { get; set; }
        public bool LikesToPlay { get; set; }
    }
}
