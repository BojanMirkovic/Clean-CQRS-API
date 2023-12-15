using Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Validators.User;
using Application.Commands.Users.RegisterNewUser;
using Application.Queries.Users.LoginUser;
using Application.Exceptions;

namespace API.Controllers.AuthUserController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthUserController : ControllerBase
    {
        // public static User user = new();
        private readonly IConfiguration _configuration;
        internal readonly IMediator _mediator;
        private readonly UserValidator _userValidator;


        //In order go gain access to Appsetings and inject configuration we have to create constructor
        public AuthUserController(IConfiguration configuration, IMediator mediator, UserValidator userValidator)
        {
            _configuration = configuration;
            _mediator = mediator;
            _userValidator = userValidator;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserDto newUser)
        {

            var userValidator = _userValidator.Validate(newUser);

            if (!userValidator.IsValid)
            {
                return BadRequest(userValidator.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            try
            {
                return Ok(await _mediator.Send(new RegisterUserCommand(newUser)));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        [Route("login")]

        public async Task<IActionResult> GetToken([FromBody] UserDto userToLogin)
        {
            //var user = await _mediator.Send(new LoginUserQuery(userLogin));

            //if (user == null)
            //{
            //    return BadRequest("User not found");

            //}
            //if (!BCrypt.Net.BCrypt.Verify(userLogin.Password,Password))
            //{
            //    return BadRequest("Wrong password");
            //}

            //return Ok(user.token);
            var inputValidation = _userValidator.Validate(userToLogin);

            if (!inputValidation.IsValid)
            {
                return BadRequest(inputValidation.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            try
            {
                string token = await _mediator.Send(new LoginUserQuery(userToLogin));

                //   return Ok(new TokenDto { TokenValue = token });
                return Ok(token);
            }
            catch (UnAuthorizedException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
