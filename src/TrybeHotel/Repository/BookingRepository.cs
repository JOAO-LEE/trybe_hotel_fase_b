using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class BookingRepository : IBookingRepository
    {
        protected readonly ITrybeHotelContext _context;
        public BookingRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        public BookingResponse Add(BookingDtoInsert booking, string email)
        {
            var foundUser = _context.Users.First(e => e.Email == email);
            Booking bookingSchedule = new()
            {
                UserId = foundUser.UserId,
                GuestQuant = booking.GuestQuant,
                CheckIn = booking.CheckIn,
                CheckOut = booking.CheckOut,
                RoomId = booking.RoomId
            };
            _context.Bookings.Add(bookingSchedule);
            _context.SaveChanges();
            return (from bookings in _context.Bookings
                    where bookings.RoomId == bookingSchedule.RoomId
                    join rooms in _context.Rooms on bookings.RoomId equals rooms.RoomId
                    join hotel in _context.Hotels on rooms.HotelId equals hotel.HotelId
                    join city in _context.Cities on hotel.CityId equals city.CityId
                    select new BookingResponse
                    {
                        BookingId = bookingSchedule.BookingId,
                        CheckIn = bookings.CheckIn,
                        CheckOut = bookings.CheckOut,
                        GuestQuant = bookings.GuestQuant,
                        Room = new RoomDto { RoomId = rooms.RoomId, Capacity = rooms.Capacity, Name = rooms.Name, Image = rooms.Image, Hotel = new HotelDto { HotelId = hotel.HotelId, Address = hotel.Address, Name = hotel.Name, CityId = city.CityId, CityName = city.Name } }
                    }).ToList().First();
        }

        public BookingResponse GetBooking(int bookingId, string email)
        {
            throw new NotImplementedException();
        }

        public Room GetRoomById(int RoomId)
        {
            var roomToSchedule = _context.Rooms.Find(RoomId);
            if (roomToSchedule == null)
            {
                return null;
            }
            return roomToSchedule;
        }

    }

}