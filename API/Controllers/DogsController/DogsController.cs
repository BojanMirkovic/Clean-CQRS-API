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
using Application.Queries.Cats.GetAllCatsByBreedAndWeight;
using Application.Validators.InputIntValidator;
using Application.Validators.StringInputValidator;

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
        private readonly StringInputValidator _stringBreedValidator;
        private readonly IntInputValidator _intWeightValidator;
        public DogsController(IMediator mediator, DogValidator dogValidator, GuidValidator guidValidator, StringInputValidator stringBreedValidator, IntInputValidator intWeightValidator)
        {
            _mediator = mediator;
            _dogValidator = dogValidator;
            _guidValidator = guidValidator;
            _stringBreedValidator = stringBreedValidator;
            _intWeightValidator = intWeightValidator;
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
        [HttpGet]
        [Route("getDogsByBreedAndWeight/{weight}, {breed}"), AllowAnonymous]
        public async Task<IActionResult> GetDogsByBreedAndWeight(string inputBreed, int inputWeight)
        {
            // Validate Color
            var validatedDogWeight = _intWeightValidator.Validate(inputWeight);
            var validatedDogBreed = _stringBreedValidator.Validate(inputBreed);
            //Error Handling
            if (!validatedDogBreed.IsValid)
            {
                return BadRequest(validatedDogBreed.Errors.ConvertAll(errors => errors.ErrorMessage));
            }
            if (!validatedDogWeight.IsValid)
            {
                return BadRequest(validatedDogWeight.Errors.ConvertAll(errors => errors.ErrorMessage));
            }
            //Try Catch
            try
            {
                return Ok(await _mediator.Send(new GetCatsByBreedAndWeightQuery(inputWeight, inputBreed)));
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
                return BadRequest(validatedDog.Errors.ConvertAll(errors => errors.ErrorMessage));
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
