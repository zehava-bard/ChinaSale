using Project.Models;
using Project.Models.DTO;

namespace Project.DAL
{
    public interface IPresentDal
    {
        public Task<IEnumerable<Presents>> Get();
        public Task<Presents> AddPresents(Presents p);
        public void RemoveById(int id);
        public Task<Presents> UpdateP(int id, PresentDTO pre);
        public Task<IEnumerable<Presents>> GetPresentByBuyer(int IdBuyer);
        public Task<List<Presents>> GetPresentByDonor(int DonorId);
        public Task<IEnumerable<Presents>> GetPresentByNumOfPurchasers(int NumOfPurchasers);
        public Task<IEnumerable<Presents>> getPresentsPurcheses(int buyerId);
        public void RemoveSeveralPresent(PresentDTO2[] presents);


    }
}
