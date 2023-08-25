using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class HotelRepository : IHotelRepository
    {
        protected readonly ITrybeHotelContext _context;
        public HotelRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        public IEnumerable<HotelDto> GetHotels()
        {
            return (from hotel in _context.Hotels
                    join city in _context.Cities on hotel.CityId equals city.CityId
                    select new HotelDto { HotelId = hotel.HotelId, Name = hotel.Name, Address = hotel.Address, CityId = city.CityId, CityName = city.Name }).ToList();
        }

        public HotelDto AddHotel(Hotel hotelToCreate)
        {
            _context.Hotels.Add(hotelToCreate);
            _context.SaveChanges();
            return (from hotel in _context.Hotels
                    where hotelToCreate.Name == hotel.Name
                    join city in _context.Cities on hotel.CityId equals city.CityId
                    select new HotelDto { HotelId = hotel.HotelId, Name = hotel.Name, Address = hotel.Address, CityId = city.CityId, CityName = city.Name }).First();
        }
    }
}