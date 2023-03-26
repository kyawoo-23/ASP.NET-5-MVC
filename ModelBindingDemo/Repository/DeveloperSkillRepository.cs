using Microsoft.EntityFrameworkCore;
using ModelBindingDemo.Data;
using ModelBindingDemo.Models;
using ModelBindingDemo.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace ModelBindingDemo.Repository
{
    public class DeveloperSkillRepository : IDeveloperSkillRepository
    {
        private readonly AppDbContext _appDbContext;
        public DeveloperSkillRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Delete(int id)
        {
            DeveloperSkill devSkill = _appDbContext.DeveloperSkills.FirstOrDefault(ds => ds.DeveloperSkillId == id);
            _appDbContext.DeveloperSkills.Remove(devSkill);
        }

        public DeveloperSkill GetDeveloperSkillById(int id)
        {
            return _appDbContext.DeveloperSkills
                .Include(d => d.Developer)
                .Include(s => s.Skill)
                .FirstOrDefault(ds => ds.DeveloperSkillId == id);
        }

        public List<DeveloperSkill> GetSkillLevelByDevId(int id)
        {
            var developerSkills = _appDbContext.DeveloperSkills
                .Where(ds => ds.DeveloperId == id)
                .Include(d => d.Developer)
                .Include(s => s.Skill)
                .ToList();
            return developerSkills;
        }

        public void Insert(DeveloperSkill model)
        {
            _appDbContext.DeveloperSkills.Add(model);
        }

        public void Save()
        {
            _appDbContext.SaveChanges();
        }
    }
}
