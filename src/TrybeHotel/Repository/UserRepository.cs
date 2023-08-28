using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class UserRepository : IUserRepository
    {
        protected readonly ITrybeHotelContext _context;
        public UserRepository(ITrybeHotelContext context)
        {
            _context = context;
        }
        public UserDto GetUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public UserDto Login(LoginDto login)
        {
            throw new NotImplementedException();
        }
        public UserDto Add(UserDtoInsert user)
        {
            User userCreation = new()
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                UserType = "client",
            };

            _context.Users.Add(userCreation);
            _context.SaveChanges();
            return (from userCreated in _context.Users
                    where userCreation.Email == userCreated.Email && userCreation.Password
                     == userCreated.Password
                    select new UserDto { UserId = userCreated.UserId, Email = userCreated.Email, Name = userCreated.Name, UserType = userCreated.UserType }).First();

        }

        public UserDto GetUserByEmail(string userEmail)
        {
            var existentUser = _context.Users.FirstOrDefault(e => e.Email == userEmail);
            if (existentUser == null)
            {
                return null;
            }
            return (from userCreated in _context.Users
                    where userEmail == userCreated.Email
                    select new UserDto { UserId = userCreated.UserId, Email = userCreated.Email, Name = userCreated.Name, UserType = userCreated.UserType }).First();
        }

        public IEnumerable<UserDto> GetUsers()
        {
            throw new NotImplementedException();
        }

    }
}