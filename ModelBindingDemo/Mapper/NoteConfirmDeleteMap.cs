using AutoMapper;
using Dev.Entities.Models;
using ModelBindingDemo.Models;

namespace Dev.Web.Mapper
{
    public class NoteConfirmDeleteMap : Profile
    {
        public NoteConfirmDeleteMap()
        {
            CreateMap<Note, ConfirmDeleteModal>()
                .ForMember(src => src.Id, act => act.MapFrom(des => des.Id))
                .ForMember(src => src.Name, act => act.MapFrom(des => des.Title))
                .ForMember(src => src.refDevId, act => act.MapFrom(des => des.DeveloperId));
        }
    }
}
