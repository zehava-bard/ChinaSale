using AutoMapper;
using Project.DAL;
using Project.Models;
using Project.Models.DTO;
using System;
using System.Collections.Generic;
namespace Project.BLL
{
    public class CardService : ICardService
    {
        private readonly ICardDal cardDal;
        private readonly IMapper _mapper;
        public CardService(ICardDal cardDal, IMapper mapper)
        {
            this.cardDal = cardDal;
            _mapper = mapper;
        }
        public async Task<int> AddCard(int presentID, int buyerId)
        {
            return await cardDal.AddCard(presentID, buyerId);
        }
        public async Task RemoveCard(int presentID, int buyerId)
        {
            await cardDal.RemoveCard(presentID, buyerId);
        }



    }



}
