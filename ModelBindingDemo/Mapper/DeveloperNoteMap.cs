using AutoMapper;
using Dev.Entities.Models;
using ModelBindingDemo.ViewModel;
using System.Collections.Generic;

namespace Dev.Web.Mapper
{
    public class DeveloperNoteMap : Profile
    {
        public DeveloperNoteMap()
        {
            CreateMap<List<Developer>, DeveloperNoteViewModel>()
                .ForMember(src => src.Developer, act => act.MapFrom(des => des));
        }
    }
}
