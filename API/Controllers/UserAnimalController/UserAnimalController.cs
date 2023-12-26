using Application.Commands.Animals.AddUserAnimalConnection;
using Application.Commands.Animals.DeleteUserAnimalConnection;
using Application.Queries.Animals.GetAllAnimals;
using Application.Queries.Animals.GetAnimalById;
using Application.Validators.GuidValidator;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.UserAnimalController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAnimalController : ControllerBase
    {
        internal readonly IMediator _mediator;
        internal readonly GuidValidator _guidValidator;

        public UserAnimalController(IMediator mediator, GuidValidator guidValidator)
        {
            _mediator = mediator;
            _guidValidator = guidValidator;
        }

        [HttpGet]
        [Route("getAllAnimals")]
        public async Task<IActionResult> GetAllAnimals()
        {
            try
            {
                return Ok(await _mediator.Send(new GetAllAnimalsQuery()));
            }
            catch (Exception ex)
            {

                throw new Exception("An error occured while getting all animals from the database", ex);
            }


        }

        [HttpGet]
        [Route("getAllAnimalsForUserById/{userId}")]
        public async Task<IActionResult> GetAllAnimalsByUserId(Guid userId)
        {
            try
            {
                var guid = _guidValidator.Validate(userId);

                if (!guid.IsValid)
                {
                    return BadRequest(guid.Errors.ConvertAll(errors => errors.ErrorMessage));
                }
                var animals = await _mediator.Send(new GetAnimalsByUserIdQuery(userId));

                if (animals == null)
                {
                    return NotFound();
                }

                return Ok(animals);

            }
            catch (Exception ex)
            {

                throw new Exception($"An error occured while getting animal for user with Id {userId}", ex);
            }


        }

        [HttpGet]
        [Route("getAnimalById/{animalId}")]
        public async Task<IActionResult> GetAnimalById(Guid animalId)
        {
            try
            {
                var guid = _guidValidator.Validate(animalId);

                if (!guid.IsValid)
                {
                    return BadRequest();
                }

                var animal = await _mediator.Send(new GetAnimalByIdQuery(animalId));

                if (animal == null)
                {
                    return NotFound();
                }

                return Ok(animal);
            }
            catch (Exception ex)
            {

                throw new Exception($"An error occured while getting an animal with Id {animalId}", ex);
            }

        }

        [HttpPost]
        [Route("addNewConnectionBetweenUserAndAnimal")]
        public async Task<IActionResult> AddNewConnectionBetweenUserAndAnimal(Guid userId, Guid animalId)
        {
            try
            {
                var userGuid = _guidValidator.Validate(userId);


                var animalguid = _guidValidator.Validate(animalId);

                if (!userGuid.IsValid || !animalguid.IsValid)
                {
                    return BadRequest();
                }

                var connection = await _mediator.Send(new AddUsersHaveAnimalsConnectionCommand(userId, animalId));

                return Ok(connection);

            }
            catch (Exception ex)
            {

                throw new Exception($"An error occured while connection userId {userId} with animalId {animalId}", ex);
            }

        }

        [HttpDelete]
        [Route("deleteConnectionBetweenUserAndAnimal")]
        public async Task<IActionResult> DeleteConnectionBetweenUserAndAnimal(Guid userId, Guid animalId)
        {
            try
            {
                var userGuid = _guidValidator.Validate(userId);

                var animalGuid = _guidValidator.Validate(animalId);

                if (!animalGuid.IsValid || !animalGuid.IsValid)
                {
                    return BadRequest();
                }

                await _mediator.Send(new DeleteUserAnimalConnectionCommand(userId, animalId));

                return NoContent();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
    }
}
