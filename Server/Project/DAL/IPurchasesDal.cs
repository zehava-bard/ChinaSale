using Project.Models;
namespace Project.DAL
{
    public interface IPurchasesDal
    {
        //public Task AddPurchase(IEnumerable<Presents> Lc, int BuyerId);
        public Task<int> AddPurchase(Purchases p);

        public Task<Purchases> ContinuePur(int BuyerID);

        public Task<List<string>> ViewAllPurchase(int id_pre);

    }
}
