using Dev.DataAccess.Repositories;
using Dev.Entities.Models;
using System.Collections.Generic;

namespace ModelBindingDemo.Repository
{
    public interface IDeveloperSkillRepository : IBaseRepository<DeveloperSkill>
    {
        DeveloperSkill GetDeveloperSkillById(int id);
        List<DeveloperSkill> GetSkillLevelByDevId (int id);
        List<DeveloperSkill> GetSkillLevelBySkillId(int id);
        //void Insert(DeveloperSkill model);
        //void Delete(int id);
    }
}
