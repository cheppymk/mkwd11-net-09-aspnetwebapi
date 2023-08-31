using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDC.NotesAppFinal.DTOs.NoteDTOs;
using SEDC.NotesAppFinal.DTOs.UserDtos;
using SEDC.NotesAppFinal.Services.Implementations;
using SEDC.NotesAppFinal.Services.Interfaces;

namespace SEDC.NotesAppFinal.Controllers
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetUserAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetAllUserAsync()
        {
            try
            {
                return Ok(await _userService.GetAllUsersAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team.");
            }
        }
        [HttpPost]
        public async Task<ActionResult> CreateUserAsync([FromBody] CreateUserDto createUserDto)
        {
            try
            {
                if (createUserDto == null || createUserDto.FirstName == null || createUserDto.LastName == null || createUserDto.Age== 0)
                {
                    return BadRequest("Invalid input");
                }

                await _userService.CreateUserAsync(createUserDto);

                return StatusCode(StatusCodes.Status201Created, "User added");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team.");
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserAsync(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("Invalid input");
                }

                await _userService.DeleteUserAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team.");
            }
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult> EditUserAsync([FromBody] CreateUserDto createUserDto, int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("Invalid input");
                }

                await _userService.EditUserAsync(createUserDto, id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team.");
            }
        }
    }
}