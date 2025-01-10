using Microsoft.AspNetCore.Mvc;
using UnitTests.Enums;
using UnitTests.Models;
using UnitTests.Services;

namespace UnitTests.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {

        private IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("login")]
        public IActionResult Login(LoginModel loginRequest)
        {
            if (string.IsNullOrWhiteSpace(loginRequest.Username) || string.IsNullOrWhiteSpace(loginRequest.Password))
            {
                return Ok(new ResponseModel(ErrorCode.InvalidInputData));
            }
            ResponseModel response = _userService.GetUserLogin(loginRequest);
            return Ok(response);
        }
    }
}
