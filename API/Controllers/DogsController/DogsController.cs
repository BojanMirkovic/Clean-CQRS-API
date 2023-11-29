﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Commands.Dogs.AddDog;
using Application.Dtos;
using Application.Queries.Dogs.GetAllDogs;
using Application.Commands.Dogs.UpdateDog;
using Application.Commands.Dogs.DeleteDog;
using Application.Queries.Dogs.GetDogById;
using Microsoft.AspNetCore.Authorization;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.DogsController
{
    [Route("api/v1/[controller]")]//v1 predstavlja verziju br.1
    [ApiController]
    [Authorize]
    public class DogsController : ControllerBase
    {
        internal readonly IMediator _mediator; //we are using mediator to comunicate with DB
        public DogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //API endpiont where we retrieve all dogs from MockDatabase
        [HttpGet]
        //url api/v1/Dogs/getAllDogs
        [Route("getAllDogs"), AllowAnonymous]
        public async Task<IActionResult> GetAllDogs()//GetAllDogs-method name
        {
            return Ok(await _mediator.Send(new GetAllDogsQuery()));
        }

        [HttpGet]
        [Route("getDogById/{dogId}"), AllowAnonymous]
        public async Task<IActionResult> GetDogById(Guid dogId)
        {
            return Ok(await _mediator.Send(new GetDogByIdQuery(dogId)));
        }

        // Create a new dog 
        [HttpPost]
        [Route("addNewDog")]
        public async Task<IActionResult> AddDog([FromBody] DogDto newDog)
        {
            return Ok(await _mediator.Send(new AddDogCommand(newDog)));
        }

        // Update a specific dog
        [HttpPut]
        [Route("updateDog/{updatedDogId}")]
        public async Task<IActionResult> UpdateDog([FromBody] DogDto updatedDog, Guid updatedDogId)
        {
            return Ok(await _mediator.Send(new UpdateDogByIdCommand(updatedDog, updatedDogId)));
        }

        // Delete a specific dog
        [HttpDelete]
        [Route("deleteDog/{dogToDeleteId}")]
        public async Task<IActionResult> DeleteDog(Guid dogToDeleteId)
        {
            return Ok(await _mediator.Send(new DeleteDogByIdCommand(dogToDeleteId)));
        }

    }
}
