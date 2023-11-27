using Application.Commands.Birds.AddBird;
using Application.Commands.Birds.DeleteBird;
using Application.Commands.Birds.UpdateBird;
using Application.Dtos;
using Application.Queries.Birds.GetAllBirds;
using Application.Queries.Birds.GetBirdById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.BirdsController
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BirdsController : ControllerBase
    {
        //Create mediator for comunication with DB
        private readonly IMediator _mediator;

        public BirdsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getAllBirds")]
        public async Task<IActionResult> GetAllBirds()
        {
            return Ok(await _mediator.Send(new GetAllBirdsQuery()));
        }

        // GET api
        [HttpGet]
        [Route("getBirdById/{birdId}")]
        public async Task<IActionResult> GetBirdById(Guid birdId)
        {
            return Ok(await _mediator.Send(new GetBirdByIdQuery(birdId)));
        }

        // Create a new bird 
        [HttpPost]
        [Route("addNewBird")]
        public async Task<IActionResult> AddBird([FromBody] BirdDto newBird)
        {
            return Ok(await _mediator.Send(new AddBirdCommand(newBird)));
        }

        // Update info of a specific bird
        [HttpPut]
        [Route("updateBirdInfo/{updatedBirdId}")]
        public async Task<IActionResult> UpdateBird([FromBody] BirdDto updatedBird, Guid updatedBirdId)
        {
            return Ok(await _mediator.Send(new UpdateBirdInfoByIdCommand(updatedBird, updatedBirdId)));
        }


        // Delete a specific bird
        [HttpDelete]
        [Route("deleteBird/{birdToDeleteId}")]
        public async Task<IActionResult> DeleteBird(Guid birdToDeleteId)
        {
            return Ok(await _mediator.Send(new DeleteBirdByIdCommand(birdToDeleteId)));
        }
    }
}
