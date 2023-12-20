using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.AnimalModel
{
    public class Bird : Animal
    {
        public required string Color { get; set; }
        public bool CanFly { get; set; }
    }
}
