using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class EntityNotFoundException : BaseCustomException
    {
        public EntityNotFoundException(string name, object key)
            : base($"Entity {name} with Id of {key} was not found IN THE DATABASE.")
        {
        }
    }
}
