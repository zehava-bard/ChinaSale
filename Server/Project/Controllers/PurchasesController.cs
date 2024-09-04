using Project.Models.DTO;
using Project.BLL;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.DAL;

namespace Project.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PurchaseController : ControllerBase
    {
        private readonly IPurchasesService _PurchaseService;

        public PurchaseController(IPurchasesService Purchase)
        {
            this._PurchaseService = Purchase;
        }

        //[HttpGet("get")]
        //public void Get()
        //{

        //}

        [HttpPost("AddNewPurchase")]
        public async Task<int> AddPurchase(PurchasesDTO c)
        {
            return await _PurchaseService.AddPurchase(c);
        }
        [HttpGet("getUserOfPresent")]
        public async Task<List<string>> ViewAllPurchase(int id_pre)
        {
            return await _PurchaseService.ViewAllPurchase(id_pre);
        }

    }
}
