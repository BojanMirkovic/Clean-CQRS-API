﻿using Application.Dtos;
using Domain.Models.AnimalModel;
using MediatR;

namespace Application.Commands.Cats.AddCat
{
    public class AddCatCommand : IRequest<Cat>
    {
        public AddCatCommand(CatDto newCat)
        {
            NewCat = newCat;
        }
        public CatDto NewCat { get; }
    }
}
