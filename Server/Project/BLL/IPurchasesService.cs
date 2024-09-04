using Project.Models;
using Project.Models.DTO;
namespace Project.BLL
{
    public interface IPurchasesService
    {
        public Task<int> AddPurchase(PurchasesDTO pdto);

        public Task<List<string>> ViewAllPurchase(int id_pre);



    }
}

