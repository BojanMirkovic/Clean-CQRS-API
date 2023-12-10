using Application.Commands.Birds.AddBird;
using Application.Commands.Birds.DeleteBird;
using Application.Commands.Birds.UpdateBird;
using Application.Dtos;
using Application.Queries.Birds.GetAllBirds;
using Application.Queries.Birds.GetBirdById;
using Application.Validators.Bird;
using Application.Validators.GuidValidator;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.BirdsController
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class BirdsController : ControllerBase
    {
        //Create mediator for comunication with DB
        private readonly IMediator _mediator;
        private readonly BirdValidator _birdValidator;
        private readonly GuidValidator _guidValidator;

        public BirdsController(IMediator mediator, BirdValidator birdValidator, GuidValidator guidValidator)
        {
            _mediator = mediator;
            _birdValidator = birdValidator;
            _guidValidator = guidValidator;
        }

        [HttpGet]
        [Route("getAllBirds"), AllowAnonymous]
        public async Task<IActionResult> GetAllBirds()
        {
            try
            {
                return Ok(await _mediator.Send(new GetAllBirdsQuery()));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // GET api
        [HttpGet]
        [Route("getBirdById/{birdId}"), AllowAnonymous]
        public async Task<IActionResult> GetBirdById(Guid birdId)
        {
            // Validate Guid id
            var validatedGuidId = _guidValidator.Validate(birdId);
            //Error Handling
            if (!validatedGuidId.IsValid)
            {
                return BadRequest(validatedGuidId.Errors.ConvertAll(errors => errors.ErrorMessage));
            }
            //Try Catch
            try
            {
                return Ok(await _mediator.Send(new GetBirdByIdQuery(birdId)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Create a new bird 
        [HttpPost]
        [Route("addNewBird"), Authorize(Roles = "admin")]
        public async Task<IActionResult> AddBird([FromBody] BirdDto newBird)
        {
            // Validate Bird
            var validatedBird = _birdValidator.Validate(newBird);
            //Error Handling
            if (!validatedBird.IsValid)
            {
                return BadRequest(validatedBird.Errors.ConvertAll(errors => errors.ErrorMessage));
            }
            //Try Catch
            try
            {
                return Ok(await _mediator.Send(new AddBirdCommand(newBird)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Update info of a specific bird
        [HttpPut]
        [Route("updateBirdInfo/{updatedBirdId}")]
        public async Task<IActionResult> UpdateBird([FromBody] BirdDto updatedBird, Guid updatedBirdId)
        {
            // Validate updatedCat, Guid updatedCatId
            var validatedUpdatedBird = _birdValidator.Validate(updatedBird);
            var validatedUpdatedBirdId = _guidValidator.Validate(updatedBirdId);
            //Error Handling
            if (!validatedUpdatedBird.IsValid)
            {
                return BadRequest(validatedUpdatedBird.Errors.ConvertAll(errors => errors.ErrorMessage));
            }
            if (!validatedUpdatedBirdId.IsValid)
            {
                return BadRequest(validatedUpdatedBirdId.Errors.ConvertAll(errors => errors.ErrorMessage));
            }
            //Try Catch
            try
            {
                return Ok(await _mediator.Send(new UpdateBirdInfoByIdCommand(updatedBird, updatedBirdId)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Delete a specific bird
        [HttpDelete]
        [Route("deleteBird/{birdToDeleteId}"), Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteBird(Guid birdToDeleteId)
        {
            // Validate Guid birdToDeleteId
            var validateBirdToDeleteId = _guidValidator.Validate(birdToDeleteId);
            //Error Handling
            if (!validateBirdToDeleteId.IsValid)
            {
                return BadRequest(validateBirdToDeleteId.Errors.ConvertAll(errors => errors.ErrorMessage));
            }
            //Try Catch
            try
            {
                return Ok(await _mediator.Send(new DeleteBirdByIdCommand(birdToDeleteId)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
