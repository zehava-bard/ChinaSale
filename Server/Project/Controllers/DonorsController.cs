using AutoMapper;
using Project.DAL;
using Project.Models;
using Project.Models.DTO;
using Project.BLL;
using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DonorsController : ControllerBase
    {
        private readonly IDonorsService _donorsService;

        public DonorsController(IDonorsService donors)
        {
            this._donorsService = donors;
        }

        [HttpGet("get")]
        public async Task<IEnumerable<Donors>> Get()
        {
            return await _donorsService.Get();
        }


        [HttpPost]
        public void AddDonors(DonorsDTO d)
        {
            _donorsService.AddDonors(d);
        }
        [HttpDelete("{id}")]
        public void RemoveById(int id)
        {
            _donorsService.RemoveById(id);
        }


        [HttpPut("updateDonor")]
        public async Task<ActionResult<DonorsDTO>> UpdateD(int id, [FromBody] DonorsDTO don)
        {
            return await _donorsService.UpdateD(id, don);
        }


        [HttpGet("getDonorByName")]
        public async Task<IEnumerable<DonorsDTO>> GetDonorByName(string nameD)
        {
            return await _donorsService.GetDonorByName(nameD);
        }
        [HttpGet("getDonorByEmail")]
        public Task<IEnumerable<Donors>>GetDonorByEmail(string Email)
        {
            return _donorsService.GetDonorByEmail(Email);
        }

        [HttpGet("getDonorByIdPresent")]
        public Task<Donors> GetDonorByPresent(int IdPresent)
        {
            return _donorsService.GetDonorByPresent(IdPresent);
        }



    }
}
