using Microsoft.AspNetCore.Mvc;
using TruyenVerse.Application.Interfaces.Services;
using TruyenVerse.Domain.Entities;

namespace TruyenVerse.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<User>> Get(Guid id)
        {
            var user = await _userService.GetUserAsync(id);
            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetAll() =>
            await _userService.GetUsersAsync();

        [HttpPost]
        public async Task<ActionResult> Create(User user)
        {
            await _userService.CreateUserAsync(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }
    }
}
