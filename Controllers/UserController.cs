using Microsoft.AspNetCore.Mvc;
using ProductApi_Task.DTOs;
using ProductApi_Task.BusinessLogic;
using System.Collections.Generic;

namespace ProductApi_Task.Controllers
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

        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("all")] // New endpoint to get all users including deleted
        public ActionResult<IEnumerable<UserDTO>> GetAllUsersIncludingDeleted()
        {
            var users = _userService.GetAllUsersIncludingDeleted();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<UserDTO> GetUserById(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null) return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public ActionResult AddUser([FromBody] UserDTO userDto)
        {
            if (userDto == null)
            {
                return BadRequest("User data is null.");
            }

            _userService.AddUser(userDto);
            return CreatedAtAction(nameof(GetUserById), new { id = userDto.UserID }, new { Message = "User added successfully." });
        }

        [HttpPut]
        public ActionResult UpdateUser([FromBody] UserDTO userDto)
        {
            if (userDto == null)
            {
                return BadRequest("User data is null.");
            }

            _userService.UpdateUser(userDto);
            return NoContent();
        }

        [HttpDelete("{id}")] // Soft delete
        public ActionResult SoftDeleteUser(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound(); // User not found
            }

            _userService.SoftDeleteUser(id);
            return NoContent();
        }

        
    }
}
