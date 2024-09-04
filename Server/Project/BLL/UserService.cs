using AutoMapper;
using Project.DAL;
using Project.Models;
using Project.Models.DTO;
namespace Project.BLL
{
    public class UserService:IUserService
    {
        private readonly IUserDal buyerDal;
        private readonly IMapper _mapper;

        public UserService(IUserDal buyerDal, IMapper mapper)
        {
            this.buyerDal = buyerDal;
            _mapper = mapper;
        }
        public async Task<User> CheckBuyer(UserDTO2 buyer)
        {
            return await buyerDal.CheckBuyer(buyer);
        }
        public async Task<User> RegisterBuyer(UserDTO buyer)
        {
            var b = _mapper.Map<User>(buyer);

            return await buyerDal.RegisterBuyer(b);
        }

        public string Generate(User buyer)
        {
            return buyerDal.Generate(buyer);
        }
        public User Authenticate(UserDTO2 buyer)
        {
            return Authenticate(buyer);
        }

    }
}
