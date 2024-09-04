using AutoMapper;
using Project.DAL;
using Project.Models;
using Project.Models.DTO;

namespace Project.BLL
{
    public class PurchasesService: IPurchasesService
    {
        private readonly IPurchasesDal purchasesDal;
        private readonly IMapper _mapper;


        public PurchasesService(IPurchasesDal purchasesDal, IMapper mapper)
        {
            this.purchasesDal = purchasesDal;
            _mapper = mapper;
        }
        public async Task<int> AddPurchase(PurchasesDTO pdto)
        {
            Purchases p = _mapper.Map<Purchases>(pdto);
            return await purchasesDal.AddPurchase(p);
        }
        public async Task<List<string>> ViewAllPurchase(int id_pre)
        {
            return await purchasesDal.ViewAllPurchase(id_pre);
        }

    }
}
