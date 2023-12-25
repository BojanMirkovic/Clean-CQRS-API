using Application.Commands.Cats.AddCat;
using Application.Commands.Cats.DeleteCat;
using Application.Commands.Cats.UpdateCat;
using Application.Dtos;
using Application.Queries.Birds.GetAllBirdsSameColor;
using Application.Queries.Cats.GetAllCats;
using Application.Queries.Cats.GetAllCatsByBreedAndWeight;
using Application.Queries.Cats.GetCatById;
using Application.Validators.Cat;
using Application.Validators.GuidValidator;
using Application.Validators.InputIntValidator;
using Application.Validators.StringInputValidator;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.CatsController
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class CatsController : ControllerBase
    {
        //Create mediator for comunication with DB
        private readonly IMediator _mediator;
        private readonly CatValidator _catValidator;
        private readonly GuidValidator _guidValidator;
        private readonly StringInputValidator _stringBreedValidator;
        private readonly IntInputValidator _intWeightValidator;

        public CatsController(IMediator mediator, CatValidator catValidator, GuidValidator guidValidator, StringInputValidator stringBreedValidator, IntInputValidator intWeightValidator)
        {
            _mediator = mediator;
            _catValidator = catValidator;
            _guidValidator = guidValidator;
            _stringBreedValidator = stringBreedValidator;
            _intWeightValidator = intWeightValidator;
        }

        [HttpGet]
        [Route("getAllCats"), AllowAnonymous]
        public async Task<IActionResult> GetAllCats()
        {
            try
            {
                return Ok(await _mediator.Send(new GetAllCatsQuery()));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // GET api
        [HttpGet]
        [Route("getCatById/{catId}"), AllowAnonymous]
        public async Task<IActionResult> GetCatById(Guid catId)
        {
            // Validate Guid id
            var validatedGuidId = _guidValidator.Validate(catId);
            //Error Handling
            if (!validatedGuidId.IsValid)
            {
                return BadRequest(validatedGuidId.Errors.ConvertAll(errors => errors.ErrorMessage));
            }
            //Try Catch
            try
            {
                return Ok(await _mediator.Send(new GetCatByIdQuery(catId)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Route("getCatsByBreedAndWeight/{weight}, {breed}"), AllowAnonymous]
        public async Task<IActionResult> GetCatsByBreedAndWeight(string inputBreed, int inputWeight)
        {
            // Validate Color
            var validatedCatWeight = _intWeightValidator.Validate(inputWeight);
            var validatedCatBreed = _stringBreedValidator.Validate(inputBreed);
            //Error Handling
            if (!validatedCatBreed.IsValid)
            {
                return BadRequest(validatedCatBreed.Errors.ConvertAll(errors => errors.ErrorMessage));
            }
            if (!validatedCatWeight.IsValid)
            {
                return BadRequest(validatedCatWeight.Errors.ConvertAll(errors => errors.ErrorMessage));
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

        // Create a new cat 
        [HttpPost]
        [Route("addNewCat"), Authorize(Roles = "admin")]
        public async Task<IActionResult> AddCat([FromBody] CatDto newCat)
        {
            // Validate Cat
            var validatedCat = _catValidator.Validate(newCat);
            //Error Handling
            if (!validatedCat.IsValid)
            {
                return BadRequest(validatedCat.Errors.ConvertAll(errors => errors.ErrorMessage));
            }
            //Try Catch
            try
            {
                return Ok(await _mediator.Send(new AddCatCommand(newCat)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Update info of a specific cat
        [HttpPut]
        [Route("updateCatInfo/{updatedCatId}"), Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateCat([FromBody] CatDto updatedCat, Guid updatedCatId)
        {
            // Validate updatedCat, Guid updatedCatId
            var validatedUpdatedCat = _catValidator.Validate(updatedCat);
            var validatedUpdatedCatId = _guidValidator.Validate(updatedCatId);
            //Error Handling
            if (!validatedUpdatedCat.IsValid)
            {
                return BadRequest(validatedUpdatedCat.Errors.ConvertAll(errors => errors.ErrorMessage));
            }
            if (!validatedUpdatedCatId.IsValid)
            {
                return BadRequest(validatedUpdatedCatId.Errors.ConvertAll(errors => errors.ErrorMessage));
            }
            //Try Catch
            try
            {
                return Ok(await _mediator.Send(new UpdateCatInfoByIdCommand(updatedCat, updatedCatId)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Delete a specific cat
        [HttpDelete]
        [Route("deleteCat/{catToDeleteId}"), Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteCat(Guid catToDeleteId)
        {
            // Validate Guid catToDeleteId
            var validateCatToDeleteId = _guidValidator.Validate(catToDeleteId);
            //Error Handling
            if (!validateCatToDeleteId.IsValid)
            {
                return BadRequest(validateCatToDeleteId.Errors.ConvertAll(errors => errors.ErrorMessage));
            }
            //Try Catch
            try
            {
                return Ok(await _mediator.Send(new DeleteCatByIdCommand(catToDeleteId)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
