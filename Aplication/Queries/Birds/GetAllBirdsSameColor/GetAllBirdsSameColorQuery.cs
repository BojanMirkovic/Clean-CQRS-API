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
        public string BirdColor { get;}
        public GetAllBirdsSameColorQuery(string color) 
        {
            BirdColor = color;
        }
    }
}
