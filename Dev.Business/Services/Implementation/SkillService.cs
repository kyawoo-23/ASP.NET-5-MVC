using Dev.Business.Services;
using Microsoft.EntityFrameworkCore;
using ModelBindingDemo.Data;
using Dev.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModelBindingDemo.Repository
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;
        public SkillService(ISkillRepository appContext)
        {
            _skillRepository = appContext;
        }

        public void Delete(int id)
        {
            _skillRepository.Delete(id);
        }

        public List<Skill> GetAllSkills()
        {
            return _skillRepository.GetAllSkills();
        }

        public Skill GetSkillById(int id)
        {
            return _skillRepository.GetSkillById(id);
        }

        public void Insert(Skill entity)
        {
            _skillRepository.Insert(entity);
        }

        public bool IsSkillNameDuplicate(string skillName)
        {
            return _skillRepository.IsSkillNameDuplicate(skillName);
        }

        public void Update(Skill skill)
        {
            _skillRepository.Update(skill);
        }
    }
}
