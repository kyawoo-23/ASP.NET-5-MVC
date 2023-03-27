using ModelBindingDemo.Models;
using ModelBindingDemo.ViewModel;
using System.Collections.Generic;

namespace ModelBindingDemo.Repository
{
    public interface IDeveloperSkillRepository
    {
        DeveloperSkill GetDeveloperSkillById(int id);
        List<DeveloperSkill> GetSkillLevelByDevId (int id);
        List<DeveloperSkill> GetSkillLevelBySkillId(int id);
        void Insert(DeveloperSkill model);
        void Delete(int id);
        void Save();
    }
}
