using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class RoomRepository : IRoomRepository
    {
        protected readonly ITrybeHotelContext _context;
        public RoomRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        public IEnumerable<RoomDto> GetRooms(int HotelId)
        {
            var foundRoom = _context.Hotels.Find(HotelId);
            return (from room in _context.Rooms
                    where HotelId == room.HotelId
                    join hotel in _context.Hotels on room.HotelId equals hotel.HotelId
                    join city in _context.Cities on hotel.CityId equals city.CityId
                    select new RoomDto { RoomId = room.RoomId, Name = room.Name, Capacity = room.Capacity, Image = room.Image, Hotel = new HotelDto { HotelId = hotel.HotelId, Name = hotel.Name, Address = hotel.Address, CityId = city.CityId, CityName = city.Name } }).ToList();
        }

        public RoomDto AddRoom(Room roomToCreate)
        {
            _context.Rooms.Add(roomToCreate);
            _context.SaveChanges();
            return (from room in _context.Rooms
                    where roomToCreate.Name == room.Name
                    join hotel in _context.Hotels on room.HotelId equals hotel.HotelId
                    join city in _context.Cities on hotel.CityId equals city.CityId
                    select new RoomDto { RoomId = room.RoomId, Name = room.Name, Capacity = room.Capacity, Image = room.Image, Hotel = new HotelDto { HotelId = hotel.HotelId, Name = hotel.Name, Address = hotel.Address, CityId = city.CityId, CityName = city.Name } }).First();
        }

        public void DeleteRoom(int RoomId)
        {
            var foundRoom = _context.Rooms.Find(RoomId);
            _context.Rooms.Remove(foundRoom);
            _context.SaveChanges();
        }
    }
}