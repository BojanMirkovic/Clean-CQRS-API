using Domain.Models.AnimalModel;
using Domain.Models.UserAnimalModel;
using MediatR;


public class GetAnimalsByUserIdQuery : IRequest<List<UserAnimalData>>
{
    public Guid UserId { get; set; }
    public GetAnimalsByUserIdQuery(Guid userId)
    {
        UserId = userId;
    }
}
