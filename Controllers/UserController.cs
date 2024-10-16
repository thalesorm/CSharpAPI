using ApiGap.Services;
using UserModel = ApiGap.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiGap.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace ApiGap.Controllers
{

    public class UserDto
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = null!;
        public string Job { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Avatar { get; set; }
        public string Status { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string IdUnity { get; set; } = null!;
    }

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "COLLABORATOR")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(string id)
        {
            try
            {
                var user = await _userService.GetById(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDto userDto)
        {
            if (string.IsNullOrEmpty(userDto.IdUnity))
            {
                return BadRequest("IdUnity é obrigatório.");
            }

            var user = new UserModel
            {
                Id = Guid.NewGuid().ToString(),
                Name = userDto.Name,
                Job = userDto.Job,
                Email = userDto.Email,
                Password = userDto.Password,
                Avatar = userDto.Avatar,
                Status = userDto.Status,
                Role = userDto.Role,
                IdUnity = userDto.IdUnity,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var createdUser = await _userService.Create(user);
            return CreatedAtAction(nameof(GetById), new { id = createdUser.Id }, createdUser);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, [FromBody] UserModel user)
        {
            try
            {
                var updatedUser = await _userService.Update(user, id);
                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                var deleted = await _userService.Delete(id);
                if (deleted)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
