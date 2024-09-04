using Project.Models;

namespace Project.DAL
{
    public interface ICardDal
    {
        public Task<IEnumerable<Purchases>> GetPurchasesByPresent(int purId);
        //  public List<Card> GetPurchesesByExpensivePresent();

        public Task<int> AddCard(int presentID, int buyerId);
        public Task RemoveCard(int presentID, int buyerId);


    }
}
