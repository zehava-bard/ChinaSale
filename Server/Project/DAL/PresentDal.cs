using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Models.DTO;
using System.Collections.Generic;

namespace Project.DAL
{
    public class PresentDal : IPresentDal
    {
        private readonly Context Context;

        public PresentDal(Context Context)
        {
            this.Context = Context;
        }
        public async Task<IEnumerable<Presents>> Get()
        {
            return await Context.Presents
                .Include(p => p.Category)
                .Include(p => p.Donors)
                .ToListAsync();
        }
        
        public async Task<Presents> AddPresents(Presents p)
        {
            var donorID = p.DonorsID;
            var donor = Context.Donors.Find(donorID);
            var categoryId = p.CategoryID;
            var category = Context.Category.Find(categoryId);
            if (donor != null&&category!=null)
            {
                var present = new Presents { DonorsID = donorID, Name=p.Name, CategoryID= categoryId, Price=p.Price};
                Context.Presents.Add(present);
                await Context.SaveChangesAsync();
            }
            else
            {
                throw new Exception();
            }
            return p;
        }
        public void RemoveById(int id)
        {
            var present = Context.Presents.FirstOrDefault(c => c.ID == id);
            if (present == null)
            {
                throw new Exception($"customer {id} not found");
            }
            Context.Presents.Remove(present);
            Context.SaveChanges();
        }

        public void RemoveSeveralPresent(PresentDTO2[] presents)
        {
            for (int i = 0; i < presents.Length; i++)
            {
                PresentDTO2 p = presents[i];
                RemoveById(p.ID);
            }
        }

        public async Task<Presents> UpdateP(int id, PresentDTO pre)
        {
            var p = Context.Presents.FirstOrDefault(c => c.ID == id);
            var category = Context.Category.FirstOrDefault(c => c.ID == pre.CategoryID);
            if (category == null)
            {
                throw new Exception("not valid category");
            }

            p.Name = pre.Name;
            p.Price = pre.Price;
            p.CategoryID = pre.CategoryID;
            p.Category = category;

            // Do not update the Donors property as it seems to be unchanged
            Context.SaveChanges();

            return p;
        }


        public async Task<IEnumerable<Presents>> GetPresentByBuyer(int IdBuyer)
        {
            IEnumerable<Presents> list = Context.Presents
                .Where(d => d.ID == IdBuyer)
                .ToList();
            await Task.Delay(100);
            return list;
        }
        public async Task<List<Presents>> GetPresentByDonor(int DonorId)
        {
            //var pre = Context.Donors
            //    .Include(d => d.Donations)
            //    .Where(d => d.ID == DonorId).ToList();

            //List<Presents> reslist =new List<Presents>();
            //return reslist;     

            List<Presents> pre = Context.Presents
                .Where(d => d.DonorsID == DonorId).ToList();
            await Task.Delay(100);
            return pre;
        }
        public async Task<IEnumerable<Presents>> GetPresentByNumOfPurchasers(int NumOfPurchasers)
        {
            List<Presents> pre = Context.Presents
               .Where(d => d.NumOfPurchasers == NumOfPurchasers).ToList();
            await Task.Delay(100);
            return pre;
        }
        public async Task<IEnumerable<Presents>> getPresentsPurcheses(int buyerId)
        {

            IEnumerable<Presents> presents = await (from c in Context.Card
                                                    join p in Context.Presents.Include(p => p.Category) on c.PresentsID equals p.ID
                                                    join pur in Context.Purchases on c.PurchasesId equals pur.ID
                                                    where pur.BuyerID == buyerId
                                                    select new Presents
                                                    {
                                                        ID = p.ID,
                                                        Name = p.Name,
                                                        Price = p.Price,
                                                        Category = p.Category
                                                    })
                                      .ToListAsync();
            return presents;
        }
    }

}


