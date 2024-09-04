using AutoMapper;
using Project.DAL;
using Project.Models.DTO;
using Project.Models;

namespace Project.BLL
{
    public interface IUserService
    { 
        public Task<User> CheckBuyer(UserDTO2 buyer);
        public Task<User> RegisterBuyer(UserDTO buyer);

        public string Generate(User buyer);
        public User Authenticate(UserDTO2 buyer);
    }
}
