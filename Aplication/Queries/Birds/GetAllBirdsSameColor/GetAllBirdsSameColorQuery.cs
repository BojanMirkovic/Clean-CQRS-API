using Application.Dtos;
using Domain.Models.AnimalModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Birds.GetAllBirdsSameColor
{
    public class GetAllBirdsSameColorQuery : IRequest<List<Bird>>
    {
        public BirdDto BirdColor { get;}
        public GetAllBirdsSameColorQuery(BirdDto color) 
        {
            BirdColor = color;
        }
    }
}
