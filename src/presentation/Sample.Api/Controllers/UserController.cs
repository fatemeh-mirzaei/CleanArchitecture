using Microsoft.AspNetCore.Mvc;
using Sample.Application.DTOs;
using Sample.Application.Interfaces;

namespace Sample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetAllUser()
        {
            var result = await _userService.GetAllUsers();

            return Ok(result);
        }


        [HttpGet("[action]")]
        public async Task<ActionResult> GetUserById(CancellationToken cancellationToken, Guid userId)
        {
            var result = await _userService.GetUserById(cancellationToken, userId);

            return Ok(result);
        }

        [HttpPut("[action]")]
        public async Task<ActionResult> CerateUser(CreateUserDto user, CancellationToken cancellationToken)
        {
            await _userService.CreateUser(user, cancellationToken);

            return Ok();
        }


        [HttpPut("[action]")]
        public async Task<ActionResult> UpdateUser(UpdateUserDto user, CancellationToken cancellationToken)
        {

            return Ok();
        }

        [HttpDelete("[action]")]
        public async Task<ActionResult> DeleteUser(Guid Id, CancellationToken cancellationToken)
        {

            return Ok();
        }
    }
}
