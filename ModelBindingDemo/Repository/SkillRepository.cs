using Microsoft.EntityFrameworkCore;
using ModelBindingDemo.Data;
using ModelBindingDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModelBindingDemo.Repository
{
    public class SkillRepository : ISkillRepository
    {
        private readonly AppDbContext _appDbContext;
        public SkillRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public bool IsSkillNameDuplicate(string skillName)
        {
            return _appDbContext.Skills.Any(s => s.SkillName == skillName);
        }

        public void Delete(int id)
        {
            Skill res = _appDbContext.Skills.FirstOrDefault(s => s.SkillId == id);
            _appDbContext.Skills.Remove(res);
        }

        public List<Skill> GetAllSkills()
        {
            List<Skill> skills = _appDbContext.Skills
                .Include(s => s.Developers)
                .Select(s => new Skill
                {
                    SkillId = s.SkillId,
                    SkillName = s.SkillName.Substring(0, 1).ToUpper() + s.SkillName.Substring(1).ToLower(),
                    Developers = s.Developers
                })
                .ToList();
            return skills;
        }

        public Skill GetSkillById(int id)
        {
            return _appDbContext.Skills.FirstOrDefault(s => s.SkillId == id);
        }

        public void Insert(Skill skill)
        {
            _appDbContext.Skills.Add(skill);
        }

        public void Save()
        {
            _appDbContext.SaveChanges();
        }

        public void Update(Skill skill)
        {
            _appDbContext.Entry(skill).State = EntityState.Modified;
        }
    }
}
