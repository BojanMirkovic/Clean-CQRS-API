using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Queries.Dogs;
using Application.Queries.Dogs.GetDogById;
using Application.Commands.Dogs.AddDog;
using Application.Dtos;
using Application.Queries.Dogs.GetAllDogs;
using Application.Commands.Dogs.UpdateDog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.DogsController
{
    [Route("api/v1/[controller]")]//v1 predstavlja verziju br.1
    [ApiController]
    public class DogsController : ControllerBase
    {
        internal readonly IMediator _mediator; //koristimo mediator da bi komunicirali sa DB
        public DogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Deat är API endpiont där vi hämtar alla hunder från MockDatabase
        [HttpGet] //HttpGet je API method za dobijanje podataka iz DB
        //url api/v1/Dogs/getAllDogs
        [Route("getAllDogs")]
        public async Task<IActionResult> GetAllDogs()//GetAllDogs-ime methoda
        {
            //Använda MediatR
            //MediatR ska ta emot REQUEST och deta då på Comands efter Queries
            // Detta är en GET då blir det en Query

            return Ok(await _mediator.Send(new GetAllDogsQuery()));//

        }

        // GET api/<DogsController>/5
        [HttpGet]
        [Route("getDogById/{dogId}")]
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

        // IMPLEMENT DELETE !!!
    }
}
