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
        .ReverseMap();
    }
  }
}
