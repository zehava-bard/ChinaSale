using Project.Models;
using Project.Models.DTO;
namespace Project.BLL
{
    public interface IPresentService
    {
        public Task<IEnumerable<PresentDTO2>> Get();
        public Task<Presents> AddPresents(PresentDTO p);
        public void RemoveById(int id);
        public Task<PresentDTO> UpdateP(int id, PresentDTO pre);
        public Task<IEnumerable<Presents>> GetPresentByBuyer(int IdBuyer);
   //     public Task<IEnumerable<Presents>> GetPresentByDonor(int DonorId);
        public Task<IEnumerable<Presents>> GetPresentByNumOfPurchasers(int NumOfPurchasers);
        public Task<IEnumerable<PresentDTO2>> getPresentsPurcheses(int buyerId);
        public void RemoveSeveralPresent(PresentDTO2[] presents);





    }
}

