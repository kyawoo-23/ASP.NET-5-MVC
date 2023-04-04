using Dev.DataAccess.Repositories.Implementation;
using Microsoft.EntityFrameworkCore;
using ModelBindingDemo.Data;
using Dev.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModelBindingDemo.Repository
{
    public class DeveloperSkillRepository : BaseRepository<DeveloperSkill>, IDeveloperSkillRepository
    {
        //private readonly AppDbContext _appDbContext;
        //public DeveloperSkillRepository(AppDbContext appDbContext)
        //{
        //    _appDbContext = appDbContext;
        //}

        //public void Delete(int id)
        //{
        //    DeveloperSkill devSkill = _appDbContext.DeveloperSkills.FirstOrDefault(ds => ds.DeveloperSkillId == id);
        //    _appDbContext.DeveloperSkills.Remove(devSkill);
        //}

        //public DeveloperSkill GetDeveloperSkillById(int id)
        //{
        //    return _appDbContext.DeveloperSkills
        //        .Include(d => d.Developer)
        //        .Include(s => s.Skill)
        //        .FirstOrDefault(ds => ds.DeveloperSkillId == id);
        //}

        //public List<DeveloperSkill> GetSkillLevelByDevId(int id)
        //{
        //    List<DeveloperSkill> devSkill = _appDbContext.DeveloperSkills
        //        .Where(ds => ds.DeveloperId == id)
        //        .Include(d => d.Developer)
        //        .Include(s => s.Skill)
        //        .ToList();
        //    return devSkill;
        //}

        //public List<DeveloperSkill> GetSkillLevelBySkillId(int id)
        //{
        //    List<DeveloperSkill> devSkill = _appDbContext.DeveloperSkills
        //        .Where(ds => ds.SkillId == id)
        //        .Include(d => d.Developer)
        //        .Include(s => s.Skill)
        //        .ToList();
        //    return devSkill;
        //}

        public override void Insert(DeveloperSkill model)
        {
            using var context = new AppDbContext();
            var exists = context.DeveloperSkills
                .FirstOrDefault(ds => ds.DeveloperId == model.DeveloperId && ds.SkillId == model.SkillId);
            if (exists != null)
            {
                throw new Exception("Duplicate data found!");
            }
            else if (model.SkillLevel < 1 || model.SkillLevel > 10)
            {
                throw new Exception("Skill level must be between 1 and 10!");
            }
            else
            {
                context.DeveloperSkills.Add(model);
                context.SaveChanges();
            }
        }

        //public void Save()
        //{
        //    _appDbContext.SaveChanges();
        //}
        public DeveloperSkill GetDeveloperSkillById(int id)
        {
            using var context = new AppDbContext();
            return context.DeveloperSkills
                .Include(d => d.Developer)
                .Include(s => s.Skill)
                .FirstOrDefault(ds => ds.DeveloperSkillId == id);
        }

        public List<DeveloperSkill> GetSkillLevelByDevId(int id)
        {
            using var context = new AppDbContext();
            return context.DeveloperSkills
                .Where(ds => ds.DeveloperId == id)
                .Include(d => d.Developer)
                .Include(s => s.Skill)
                .ToList();
        }

        public List<DeveloperSkill> GetSkillLevelBySkillId(int id)
        {
            using var context = new AppDbContext();
            return context.DeveloperSkills
                .Where(ds => ds.SkillId == id)
                .Include(d => d.Developer)
                .Include(s => s.Skill)
                .ToList();
        }
    }
}
