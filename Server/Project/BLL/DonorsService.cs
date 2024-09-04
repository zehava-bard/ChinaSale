using AutoMapper;
using Project.DAL;
using Project.Models;
using Project.Models.DTO;
using System.Collections.Generic;

namespace Project.BLL;
public class DonorsService:IDonorsService
{
    private readonly IDonorsDal donorsDal;
    private readonly IMapper _mapper;
    public DonorsService(IDonorsDal donorsDal, IMapper mapper)
    {
        this.donorsDal = donorsDal;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Donors>> Get()
    {
        var p = await donorsDal.Get();
        return p;
    }

    public async Task<Donors> AddDonors(DonorsDTO d)
    {
        var p = _mapper.Map<Donors>(d);
        return await donorsDal.AddDonors(p);
    }
    public void RemoveById(int id)
    {
        donorsDal.RemoveById(id);
    }
    public async Task<DonorsDTO> UpdateD(int id, DonorsDTO don)
    {
        var dre = _mapper.Map<DonorsDTO>(await donorsDal.UpdateD(id, don));
        return dre;
    }

    public async Task<IEnumerable<DonorsDTO>> GetDonorByName(string nameD)
    {
        var p =await donorsDal.GetDonorByName(nameD);
        IEnumerable<DonorsDTO> reslist =  (IEnumerable<DonorsDTO>)(_mapper.Map<DonorsDTO>(p));
        return reslist;
        //return donorsDal.GetDonorByName(nameD);
    }
    public async Task<IEnumerable<Donors>> GetDonorByEmail(string Email)
    {
        return await donorsDal.GetDonorByEmail(Email);
    }

    public async Task<Donors> GetDonorByPresent(int IdPresent)
    {
        return await donorsDal.GetDonorByPresent(IdPresent);

    }



}
