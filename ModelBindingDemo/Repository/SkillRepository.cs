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

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Skill> GetAllSkills()
        {
            return _appDbContext.Skills.Include(s => s.Developers).ToList();
        }

        public Skill GetSkillById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(Note model)
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Note note)
        {
            throw new System.NotImplementedException();
        }
    }
}
