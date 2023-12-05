using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Commands.Dogs.AddDog;
using Application.Dtos;
using Application.Queries.Dogs.GetAllDogs;
using Application.Commands.Dogs.UpdateDog;
using Application.Commands.Dogs.DeleteDog;
using Application.Queries.Dogs.GetDogById;
using Microsoft.AspNetCore.Authorization;
using Application.Validators.Dog;
using Application.Validators.GuidValidator;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.DogsController
{
    [Route("api/v1/[controller]")]//v1 predstavlja verziju br.1
    [ApiController]
  //  [Authorize]
    public class DogsController : ControllerBase
    {
        internal readonly IMediator _mediator; //we are using mediator to comunicate with DB
        internal readonly DogValidator _dogValidator;
        internal readonly GuidValidator _guidValidator;
        public DogsController(IMediator mediator, DogValidator dogValidator, GuidValidator guidValidator )
        {
            _mediator = mediator;
            _dogValidator = dogValidator;
            _guidValidator = guidValidator;
        }

        //API endpiont where we retrieve all dogs from MockDatabase
        [HttpGet]
        //url api/v1/Dogs/getAllDogs
        [Route("getAllDogs"), AllowAnonymous]
        public async Task<IActionResult> GetAllDogs()//GetAllDogs-method name
        {
            try
            {
                return Ok(await _mediator.Send(new GetAllDogsQuery()));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

           
        }

        [HttpGet]
        [Route("getDogById/{dogId}"), AllowAnonymous]
        public async Task<IActionResult> GetDogById(Guid dogId)
        {
            // Validate Guid id
            var validatedGuidId = _guidValidator.Validate(dogId);
            //Error Handling
            if (!validatedGuidId.IsValid)
            {
                return BadRequest(validatedGuidId.Errors.ConvertAll(errors => errors.ErrorMessage));
            }
            //Try Catch
            try
            {
                return Ok(await _mediator.Send(new GetDogByIdQuery(dogId)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Create a new dog 
        [HttpPost]
        [Route("addNewDog")]
        public async Task<IActionResult> AddDog([FromBody] DogDto newDog)
        {
            // Validate Dog
            var validatedDog = _dogValidator.Validate(newDog);
            //Error Handling
            if (!validatedDog.IsValid)
            {
              return BadRequest(validatedDog.Errors.ConvertAll(errors=>errors.ErrorMessage));
            }
            //Try Catch
            try 
            { 
                return Ok(await _mediator.Send(new AddDogCommand(newDog)));
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
          
        }

        // Update a specific dog
        [HttpPut]
        [Route("updateDog/{updatedDogId}")]
        public async Task<IActionResult> UpdateDog([FromBody] DogDto updatedDog, Guid updatedDogId)
        {
            // Validate updatedDog, Guid updatedDogId
            var validatedUpdatedDog = _dogValidator.Validate(updatedDog);
            var validatedUpdatedDogId = _guidValidator.Validate(updatedDogId);
            //Error Handling
            if (!validatedUpdatedDog.IsValid)
            {
                return BadRequest(validatedUpdatedDog.Errors.ConvertAll(errors => errors.ErrorMessage));
            }
            if (!validatedUpdatedDogId.IsValid)
            {
                return BadRequest(validatedUpdatedDogId.Errors.ConvertAll(errors => errors.ErrorMessage));
            }
            //Try Catch
            try
            {
                return Ok(await _mediator.Send(new UpdateDogByIdCommand(updatedDog, updatedDogId)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

           
        }

        // Delete a specific dog
        [HttpDelete]
        [Route("deleteDog/{dogToDeleteId}")]
        public async Task<IActionResult> DeleteDog(Guid dogToDeleteId)
        {
            // Validate Guid dogToDeleteId
            var validateDogToDeleteId = _guidValidator.Validate(dogToDeleteId);
            //Error Handling
            if (!validateDogToDeleteId.IsValid)
            {
                return BadRequest(validateDogToDeleteId.Errors.ConvertAll(errors => errors.ErrorMessage));
            }
            //Try Catch
            try
            {
                return Ok(await _mediator.Send(new DeleteDogByIdCommand(dogToDeleteId)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

    }
}
