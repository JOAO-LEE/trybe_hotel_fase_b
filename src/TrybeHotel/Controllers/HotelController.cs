using Microsoft.AspNetCore.Mvc;
using TrybeHotel.Models;
using TrybeHotel.Repository;
using TrybeHotel.Dto;
using Microsoft.AspNetCore.Authorization;

namespace TrybeHotel.Controllers
{
    [ApiController]
    [Route("hotel")]
    public class HotelController : Controller
    {
        private readonly IHotelRepository _repository;

        public HotelController(IHotelRepository repository)
        {
            _repository = repository;
        }

        // 4. Desenvolva o endpoint GET /hotel
        [HttpGet]
        public IActionResult GetHotels()
        {

            var allHotels = _repository.GetHotels();
            return Ok(allHotels);
        }

        // 5. Desenvolva o endpoint POST /hotel
        [HttpPost]
        [Authorize(Policy = "Admin")]
        public IActionResult PostHotel([FromBody] Hotel hotel)
        {
            var createdHotel = _repository.AddHotel(hotel);
            return Created("", createdHotel);
        }
    }
}