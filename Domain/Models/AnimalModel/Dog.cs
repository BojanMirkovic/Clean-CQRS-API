

namespace Domain.Models.AnimalModel
{
    public class Dog : Animal
    {
        public required string Breed { get; set; }
        public int Weight { get; set; }
        public string Bark()
        {
            return "This animal barks";
        }
    }
}
