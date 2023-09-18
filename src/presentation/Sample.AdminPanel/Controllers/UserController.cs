using Microsoft.AspNetCore.Mvc;
using Sample.Application.DTOs;
using Sample.Application.Interfaces;

namespace Sample.AdminPanel.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Users(FilterUserDto filter)
        {
            return View(await _userService.GetAllUsers(filter));
        }


        [HttpGet("CreateUser")]
        public IActionResult CreateUser()
        {

            return View();
        }


        [HttpPost("CreateUser")]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> CreateUser(CreateUserDto user, CancellationToken cancellationToken)
        {
            await _userService.CreateUser(user, cancellationToken);
            return View();
        }


        [HttpGet("UpdateUser")]
        public IActionResult UpdateUser(Guid userId)
        {

            return View();
        }


        [HttpPost("UpdateUser")]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> UpdateUser(UpdateUserDto userDto, CancellationToken cancellationToken)
        {
            await _userService.UpdateUser(userDto, cancellationToken);
            return View();
        }

    }
}
