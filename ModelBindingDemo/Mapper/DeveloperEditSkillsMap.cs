using AutoMapper;
using Dev.Entities.Models;
using ModelBindingDemo.ViewModel;
using System.Collections.Generic;

namespace Dev.Web.Mapper
{
    public class DeveloperEditSkillsMap : Profile
    {
        public DeveloperEditSkillsMap()
        {
            CreateMap<(Developer s1, List<Skill> s2, List<DeveloperSkill> s3), DeveloperEditSkillsViewModel>()
                  .ForMember(sss => sss.Developer, m => m.MapFrom(source => source.s1))
                  .ForMember(sss => sss.Skills, m => m.MapFrom(source => source.s2))
                  .ForMember(sss => sss.DeveloperSkills, m => m.MapFrom(source => source.s3));
        }
    }
}
