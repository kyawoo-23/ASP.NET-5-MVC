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
