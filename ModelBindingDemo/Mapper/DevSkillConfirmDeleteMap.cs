using AutoMapper;
using Dev.Entities.Models;
using ModelBindingDemo.Models;

namespace Dev.Web.Mapper
{
    public class DevSkillConfirmDeleteMap : Profile
    {
        public DevSkillConfirmDeleteMap()
        {
            CreateMap<DeveloperSkill, ConfirmDeleteModal>()
                .ForMember(des => des.Id, act => act.MapFrom(src => src.DeveloperSkillId))
                .ForMember(des => des.Name, act => act.MapFrom(src => src.Skill.SkillName + " from " + src.Developer.Name))
                .ForMember(des => des.refDevId, act => act.MapFrom(src => src.DeveloperId));
        }
    }
}
