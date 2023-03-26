using ModelBindingDemo.Models;
using System.Collections.Generic;

namespace ModelBindingDemo.Repository
{
    public interface ISkillRepository
    {
        List<Skill> GetAllSkills();
        Skill GetSkillById(int id);
        void Insert(Skill skill);
        void Update(Skill skill);
        void Delete(int id);
        void Save();
    }
}
