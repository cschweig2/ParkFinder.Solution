using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ParkFinder.Services;
using ParkFinder.Models;

namespace ParkFinder.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/{v:ApiVersion}/users")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private ParkFinderContext _db;

        public UsersController(IUserService userService, ParkFinderContext db)
        {
            _userService = userService;
            _db = db;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User userParam)
        {
            var user = _userService.Authenticate(userParam.Username, userParam.Password);
            if (user == null)
            {
                return BadRequest(new { message = "Username or password is incorrect"});
            }
            return Ok(user);
        }

        // [HttpGet]
        // public IActionResult GetAll()
        // {
        //     var users = _db.Users.GetAll();
        //     return Ok(users);
        // }
    }
}