using ModelBindingDemo.Models;
using ModelBindingDemo.ViewModel;
using System.Collections.Generic;

namespace ModelBindingDemo.Repository
{
    public interface IDeveloperSkillRepository
    {
        List<DeveloperSkill> GetSkillLevelByDevId (int id);
        void Insert(DeveloperSkill model);
        void Save();
    }
}
