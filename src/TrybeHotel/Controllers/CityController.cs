using Microsoft.AspNetCore.Mvc;
using TrybeHotel.Models;
using TrybeHotel.Repository;

// começando o projeto!! #vqv

namespace TrybeHotel.Controllers
{
    [ApiController]
    [Route("city")]
    public class CityController : Controller
    {
        private readonly ICityRepository _repository;
        public CityController(ICityRepository repository)
        {
            _repository = repository;
        }

        // 2. Desenvolva o endpoint GET /city
        [HttpGet]
        public IActionResult GetCities()
        {
            var allCities = _repository.GetCities();
            return Ok(allCities);
        }

        // 3. Desenvolva o endpoint POST /city
        [HttpPost]
        public IActionResult PostCity([FromBody] City city)
        {
            var createdCity = _repository.AddCity(city);
            return Created("", createdCity);
        }
    }
}