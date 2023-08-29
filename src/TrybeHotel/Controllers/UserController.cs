using Microsoft.AspNetCore.Mvc;
using TrybeHotel.Models;
using TrybeHotel.Repository;
using TrybeHotel.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace TrybeHotel.Controllers
{
    [ApiController]
    [Route("user")]

    public class UserController : Controller
    {
        private readonly IUserRepository _repository;
        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Authorize(Policy = "Admin")]
        public IActionResult GetUsers()
        {
            var allUsers = _repository.GetUsers();
            return Ok(allUsers);
        }

        [HttpPost]
        public IActionResult Add([FromBody] UserDtoInsert user)
        {
            var doesUserExist = _repository.GetUserByEmail(user.Email);
            if (doesUserExist != null)
            {
                return Conflict(new { message = "User email already exists" });
            }
            var createdUser = _repository.Add(user);
            return Created("", createdUser);
        }
    }
}