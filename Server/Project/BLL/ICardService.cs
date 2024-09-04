using Project.Models;
using Project.Models.DTO;
namespace Project.BLL
{
    public interface ICardService
    {
        public Task<int> AddCard(int presentID, int buyerId);
        public Task RemoveCard(int presentID, int buyerId);

    }
}
