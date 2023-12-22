using Domain.Models.Account;
using Domain.Models.AnimalModel;

namespace Domain.Models.UserModel
{
    public class User : AccountModel
    {
        public string Role { get; set; } = "user";

    }
}
