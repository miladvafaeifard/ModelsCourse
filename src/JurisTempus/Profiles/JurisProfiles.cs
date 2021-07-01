using System;
using AutoMapper;
using JurisTempus.Data.Entities;
using JurisTempus.ViewModels;

namespace JurisTempus.Profiles
{
  public class JurisProfiles: Profile
  {
    public JurisProfiles()
    {
      CreateMap<Client, ClientViewModel>()
        .ForMember(d => d.ContactName, opts => opts.MapFrom(src => src.Contact))
        .ForMember(d => d.Address1, opts => opts.MapFrom(src => src.Address.Address1))
        .ForMember(d => d.Address2, opts => opts.MapFrom(src => src.Address.Address2))
        .ForMember(d => d.Address3, opts => opts.MapFrom(src => src.Address.Address3))
        .ForMember(d => d.CityTown, opts => opts.MapFrom(src => src.Address.CityTown))
        .ForMember(d => d.Country, opts => opts.MapFrom(src => src.Address.Country))
        .ForMember(d => d.PostalCode, opts => opts.MapFrom(src => src.Address.PostalCode))
        .ForMember(d => d.StateProvince, opts => opts.MapFrom(src => src.Address.StateProvince))
        .ReverseMap();
    }
  }
}
