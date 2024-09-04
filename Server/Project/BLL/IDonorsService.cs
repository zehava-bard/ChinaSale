using Project.Models;
using Project.Models.DTO;
namespace Project.BLL
{
    public interface IDonorsService
    {
        public Task<IEnumerable<Donors>> Get();

        public Task<Donors> AddDonors(DonorsDTO d);
        public void RemoveById(int id);
        public Task<DonorsDTO> UpdateD(int id, DonorsDTO don);
        /*כי הרי זה לא חוזר למשתמש DTO לבדוק האם לשנות שיחזיר בלי */
        public Task<IEnumerable<DonorsDTO>> GetDonorByName(string nameD);
        public Task<IEnumerable<Donors>> GetDonorByEmail(string Email);
        public Task<Donors> GetDonorByPresent(int IdPresent);



    }
}
