using Dev.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Business.Services
{
    public interface ISkillService : IBaseService<Skill>
    {
        List<Skill> GetAllSkills();
        Skill GetSkillById(int id);
        //void Insert(Skill skill);
        void Update(Skill skill);
        //void Delete(int id);
        //void Save();
        bool IsSkillNameDuplicate(string skillName);
    }
}
