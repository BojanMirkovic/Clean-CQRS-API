using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class CatDto
    {
        public string Name { get; set; } = string.Empty;
        public string Breed { get; set; } = string.Empty;
        public int Weight { get; set; }
        public bool LikesToPlay { get; set; }
    }
}

