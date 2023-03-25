using ModelBindingDemo.Models;
using System.Collections.Generic;

namespace ModelBindingDemo.Repository
{
    public interface ISkillRepository
    {
        List<Skill> GetAllSkills();
        Skill GetSkillById(int id);
        void Insert(Note model);
        void Update(Note note);
        void Delete(int id);
        void Save();
    }
}
