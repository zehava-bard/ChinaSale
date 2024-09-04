using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Models.DTO;

namespace Project.DAL
{
    public class CardDal : ICardDal
    {
        private readonly Context Context;

        public CardDal(Context Context)
        {
            this.Context = Context;
        }
        public async Task<IEnumerable<Purchases>> GetPurchasesByPresent(int purId)
        {
            IEnumerable<Purchases> list = Context.Purchases
                .Where(d => d.ID == purId)
                .ToList();
            await Task.Delay(100);
            return list;
        }
        public async Task<int> AddCard(int presentID, int buyerId)
        {

            Purchases p1 = Context.Purchases.FirstOrDefault(i => i.BuyerID == buyerId && i.status == false);
           // p1.NumberOfTicket = p1.NumberOfTicket + 1;
            Card newC = new Card() { PresentsID = presentID, PurchasesId = p1.ID };
            try
            {
                Context.Card.Add(newC);
                int id = Context.SaveChanges();
                await Task.Delay(100);
                return newC.Id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task RemoveCard(int presentID, int buyerId)
        {
            Purchases p1 = Context.Purchases.FirstOrDefault(i => i.BuyerID == buyerId && i.status == false);
            p1.NumberOfTicket = p1.NumberOfTicket - 1;
            var c1 = Context.Card.FirstOrDefault(i => i.PresentsID == presentID && i.PurchasesId == p1.ID);
            Context.Card.Remove(c1);
            p1.NumberOfTicket = p1.NumberOfTicket - 1;
            await Context.SaveChangesAsync();
        }
    }




}

