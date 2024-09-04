using Project.Models.DTO;
using Project.BLL;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.DAL;

namespace Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardController(ICardService card)
        {
            this._cardService = card;
        }

        [HttpGet("get")]
        public void Get()
        {
           
        }

        [HttpPost("AddNewCard{presentID},{buyerId}")]
        public async Task<int> AddCard(int presentID, int buyerId)
        {
            return await _cardService.AddCard(presentID, buyerId);
        }

        [HttpDelete("RemoveCard{presentID},{buyerId}")]
        public async Task RemoveCard(int presentID, int buyerId)
        {
            await _cardService.RemoveCard(presentID, buyerId);
        }

    }
}
