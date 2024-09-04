
using Project.DAL;
using Project.Models;
using Project.Models.DTO;
using Project.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;

namespace Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PresentController : ControllerBase
    {
        private readonly IPresentService _presentsService;
        public PresentController(IPresentService present)
        {
            this._presentsService = present;
        }

        [HttpGet("getAll")]       
        public async Task<IEnumerable<PresentDTO2>> Get()
        {
            return await _presentsService.Get();
        }

        [HttpGet("getPresentsPurcheses{buyerId}")]
        public async Task<IEnumerable<PresentDTO2>> getPresentsPurcheses(int buyerId)
        {
            return await _presentsService.getPresentsPurcheses(buyerId);
        }


        [HttpPost("AddNewPresent")]
        //[Authorize(Roles ="Manager")]
        public async Task AddPresents([FromBody] PresentDTO p)
        {
            await _presentsService.AddPresents(p);
        }

        [HttpPut("updatePresent")]
        public async Task<ActionResult<PresentDTO>> UpdateP(int id, [FromBody] PresentDTO pre)
        {
            return await _presentsService.UpdateP(id, pre);
        }


        [HttpDelete("{id}")]
        //[Authorize(Roles = "Manager")]
        public void RemoveById(int id)
        {
            _presentsService.RemoveById(id);
        }


        [HttpDelete("deleteSeveralPresents")]
        //[Authorize(Roles = "Manager")]
        public IActionResult RemoveSeveralPresent(PresentDTO2[] presents)
        {
            if (presents == null || presents.Length == 0)
            {
                return BadRequest("The presents list is empty or null.");
            }

            _presentsService.RemoveSeveralPresent(presents);
            return NoContent();
        }



        //[HttpPut("updatePresent{id}")]
        //public async Task<PresentDTO> UpdateP(int id, PresentDTO pre)
        //{
        //    return await _presentsService.UpdateP(id, pre);
        //}


  


        //[HttpPut("updatePresent")]
        //public async Task<PresentDTO> UpdateP(PresentDTO pre)
        //{
        //    return BadRequestResult();
        //}

        //private PresentDTO BadRequestResult()
        //{
        //    throw new NotImplementedException();
        //}

        [HttpGet("GetPresentByBuyer{IdBuyer}")]
        public Task<IEnumerable<Presents>> GetPresentByBuyer(int IdBuyer)
        {
            return _presentsService.GetPresentByBuyer(IdBuyer);
        }
        [HttpGet("getPresentByDonorId")]
     //   public IEnumerable<Presents> GetPresentByDonor(int DonorId)
    //    {
    //        return _presentsService.GetPresentByDonor(DonorId);
    //    }
        [HttpGet("getPresentByNumOfPurchasers")]
        public Task<IEnumerable<Presents>> GetPresentByNumOfPurchasers(int NumOfPurchasers)
        {
            return _presentsService.GetPresentByNumOfPurchasers(NumOfPurchasers);
        }

    }
}

