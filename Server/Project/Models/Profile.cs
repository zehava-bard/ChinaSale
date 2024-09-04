using Project.Models.DTO;
using AutoMapper;
using System.Collections.Generic;
using Project.DAL;
namespace Project.Models;

public class ProFile : Profile
{
    public ProFile()
    {
        CreateMap<DonorsDTO, Donors>();
        CreateMap<Donors, DonorsDTO>();

        CreateMap<DonorsDTO2, Donors>();
        CreateMap<Donors, DonorsDTO2>();

        CreateMap<PresentDTO, Presents>();
        CreateMap<Presents, PresentDTO>();

        CreateMap<PresentDTO2, Presents>();
        CreateMap<Presents, PresentDTO2>();

        CreateMap<UserDTO, User>();
        CreateMap<User, UserDTO>();

        CreateMap<CardDTO, Card>();
        CreateMap<Card, CardDTO>();


        CreateMap<PurchasesDTO, Purchases>();
        CreateMap<Purchases, PurchasesDTO>();


    }


}
