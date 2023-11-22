using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Animal
{
    public class Dog : Animal
    {
        public string Bark()
        {
            return "This animal barks";
        }
    }
}
