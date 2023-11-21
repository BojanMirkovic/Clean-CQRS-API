using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{public class Animal
    {
        public Guid animalId {  get; set; }
        public string Name { get; set; } = string.Empty;//umesto da pisemo =null, stirng.Empty
    };
}
