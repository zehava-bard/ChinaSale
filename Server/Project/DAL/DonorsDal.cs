using Project.Models;
using Project.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
namespace Project.DAL
{
    public class DonorsDal : IDonorsDal
    {
        private readonly Context Context;

        public DonorsDal(Context Context)
        {
            this.Context = Context;
        }
        public async Task<IEnumerable<Donors>> Get()
        {
            return await Context.Donors.ToListAsync();
        }
        public async Task<Donors> AddDonors(Donors d)
        {
            try
            {
                Context.Donors.Add(d);
                int id = Context.SaveChanges();
                d.ID = id;
                await Task.Delay(100);
                return d;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void RemoveById(int id)
        {
            var donor = Context.Donors.FirstOrDefault(c => c.ID == id);
            if (donor == null)
            {
                throw new Exception($"customer {id} not found");
            }
            Context.Donors.Remove(donor);
            Context.SaveChanges();
        }

        public async Task<Donors> UpdateD(int id, DonorsDTO don)
        {
           
            var d = Context.Donors.FirstOrDefault(c => c.ID == id);

            d.Name = don.Name;
            d.Phone = don.Phone;
            d.Email = don.Email;

            Context.SaveChanges();

           return d;
        }
        public async Task<IEnumerable<Donors>> GetDonorByName(string nameD)
        {
            //IEnumerable<Donors> list = Context.Donors;       
            //return list.FindAll(c => c.Name == nameD);

            IEnumerable<Donors> list= Context.Donors
                .Where(d => d.Name == nameD)
                .ToList();
            await Task.Delay(100);
            return list;

        }
        public async Task<IEnumerable<Donors>> GetDonorByEmail(string Email)
        {
            IEnumerable<Donors> list = Context.Donors
                .Where(d => d.Email == Email)
                .ToList();
            await Task.Delay(100);
            return list;
        }
        public Task<Donors> GetDonorByPresent(int IdPresent)
        {
            //var don = Context.Presents
            //    .Include(p => p.Donors)
            //    .Select(p => p.Donors)
            //    .Where(p => p.ID == IdPresent);
            //Donors d = new Donors();
            // return d;

            //var pre = Context.Donors
            //.Include(d => d.Donations).
            //ThenInclude(dna => dna.ID)
            //.Where(dna => dna.ID == IdPresent);
            //return null;

            //var pre = Context.Donors
            //    .Include(d => d.Donations)
            //    .Where(d => d.ID == DonorId).ToList();

            //List<Presents> reslist =new List<Presents>();
            //return reslist;    
            //var donor=Context.Donors
            //    .Include(don=>don.Donation)
            //    .thenInclude(p=>p.)
            //var donor=Context.Donors.include




            return null;

        }

    }
}
