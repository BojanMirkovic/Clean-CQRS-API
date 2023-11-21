using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Queries.Dogs;
using Application.Queries.Dogs.GetDogById;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/v1/[controller]")]//v1 predstavlja verziju br.1
    [ApiController]
    public class DogsController : ControllerBase
    {
        internal readonly IMediator _mediatR; //koristimo mediatR da bi komunicirali sa DB
        public DogsController(IMediator mediatR)
        {
          _mediatR = mediatR;
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

            return Ok(await _mediatR.Send(new GetAllDogsQuery()));//

        }

        // GET api/<DogsController>/5
        [HttpGet]
        [Route("getDogById/{dogId}")]
        public async Task<IActionResult> GetDogById(Guid dogId)
        {
            return Ok(await _mediatR.Send(new GetDogByIdQuery(dogId)));
        }

        // POST api/<DogsController>
        [HttpPost]
        [Route("createNewDog")]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DogsController>/5
        [HttpPut]
        [Route("updateDogById/{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DogsController>/5
        [HttpDelete]
        [Route("deleteDogById/{id}")]
        public void Delete(int id)
        {
        }
    }
}
