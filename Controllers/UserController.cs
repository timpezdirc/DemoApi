using DemoApi.Models;
using DemoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(new { st = _userService.GetUsers().Count, seznam = _userService.GetUsers() });
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            if(string.IsNullOrEmpty(user.Ime) || user == null)
            {
                return BadRequest("Neveljaven vnos.");
            }

            _userService.AddUser(user);
            return Ok(new { st = _userService.GetUsers().Count, seznam = _userService.GetUsers() });
        }
    }
}
