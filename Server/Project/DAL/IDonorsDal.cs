using Project.Models;
using Project.Models.DTO;
namespace Project.DAL
{
    public interface IDonorsDal
    {
        public Task<IEnumerable<Donors>> Get();
        public Task<Donors> AddDonors(Donors d);
        public void RemoveById(int id);
        public Task<Donors> UpdateD(int id, DonorsDTO don);
        public Task<IEnumerable<Donors>> GetDonorByName(string nameD);
        public Task<IEnumerable<Donors>> GetDonorByEmail(string Email);
        public Task<Donors> GetDonorByPresent(int IdPresent);



    }
}
