using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Animal
{
    public class Animal
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;//umesto da pisemo =null, stirng.Empty
    };
}
