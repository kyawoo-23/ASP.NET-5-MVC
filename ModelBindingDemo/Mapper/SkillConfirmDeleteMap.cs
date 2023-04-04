using AutoMapper;
using Dev.Entities.Models;
using ModelBindingDemo.Models;

namespace Dev.Web.Mapper
{
    public class SkillConfirmDeleteMap : Profile
    {
        public SkillConfirmDeleteMap()
        {
            CreateMap<Skill, ConfirmDeleteModal>()
                .ForMember(src => src.Id, act => act.MapFrom(des => des.SkillId))
                .ForMember(src => src.Name, act => act.MapFrom(des => des.SkillName));
        }
    }
}
