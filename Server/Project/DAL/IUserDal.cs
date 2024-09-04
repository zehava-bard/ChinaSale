using Project.Models;
using Project.Models.DTO;

namespace Project.DAL
{
    public interface IUserDal
    {
        public Task<User> CheckBuyer(UserDTO2 buyer);
        public Task<User> RegisterBuyer(User buyer);
        //login
        public string Generate(User buyer);
        public User Authenticate(UserDTO2 buyer);

    }
}
