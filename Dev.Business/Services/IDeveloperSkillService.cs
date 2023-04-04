using Dev.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Business.Services
{
    public interface IDeveloperSkillService : IBaseService<DeveloperSkill>
    {
        DeveloperSkill GetDeveloperSkillById(int id);
        List<DeveloperSkill> GetSkillLevelByDevId(int id);
        List<DeveloperSkill> GetSkillLevelBySkillId(int id);
    }
}
