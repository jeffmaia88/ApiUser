using Microsoft.AspNetCore.Mvc;
using API.Services;
using API.Models;

namespace API.Controllers
{
    [ApiController]
    [Route("v1/users")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserRequest>>> GetUsers()
        {
            var users = await _userService.GetUsersRequest();
            return Ok(users);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var user = await _userService.GetByIdUserRequest(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);

        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] UserRequest userRequest)
        {
            var user = await _userService.CreateUserRequest(userRequest);
            return Ok(user);
        }



        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] UserRequest userRequest)
        {
            var user = await _userService.UpdateUserRequest(id, userRequest);
            if (user == null)
            {
            }

            return Ok(user);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var user = await _userService.DeleteUserRequest(id);
            if (user == false)
            {
                return NotFound();
            }

            return Ok();
        }



    }
}
