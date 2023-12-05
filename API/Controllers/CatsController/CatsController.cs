using Application.Commands.Cats.AddCat;
using Application.Commands.Cats.DeleteCat;
using Application.Commands.Cats.UpdateCat;
using Application.Dtos;
using Application.Queries.Cats.GetAllCats;
using Application.Queries.Cats.GetCatById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.CatsController
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class CatsController : ControllerBase
    {
        //Create mediator for comunication with DB
        private readonly IMediator _mediator;

        public CatsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getAllCats"), AllowAnonymous]
        public async Task<IActionResult> GetAllCats()
        {
            return Ok(await _mediator.Send(new GetAllCatsQuery()));
        }

        // GET api
        [HttpGet]
        [Route("getCatById/{catId}"), AllowAnonymous]
        public async Task<IActionResult> GetCatById(Guid catId)
        {
            return Ok(await _mediator.Send(new GetCatByIdQuery(catId)));
        }

        // Create a new cat 
        [HttpPost]
        [Route("addNewCat"), Authorize(Roles = "admin")]
        public async Task<IActionResult> AddCat([FromBody] CatDto newCat)
        {
            return Ok(await _mediator.Send(new AddCatCommand(newCat)));
        }

        // Update info of a specific cat
        [HttpPut]
        [Route("updateCatInfo/{updatedCatId}"), Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateCat([FromBody] CatDto updatedCat, Guid updatedCatId)
        {
            return Ok(await _mediator.Send(new UpdateCatInfoByIdCommand(updatedCat, updatedCatId)));
        }

        // Delete a specific cat
        [HttpDelete]
        [Route("deleteCat/{catToDeleteId}"), Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteCat(Guid catToDeleteId)
        {
            return Ok(await _mediator.Send(new DeleteCatByIdCommand(catToDeleteId)));
        }
    }
}
