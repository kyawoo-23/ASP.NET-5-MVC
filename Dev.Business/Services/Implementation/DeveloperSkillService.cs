using Dev.Business.Services;
using Microsoft.EntityFrameworkCore;
using ModelBindingDemo.Data;
using Dev.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModelBindingDemo.Repository
{
    public class DeveloperSkillService : IDeveloperSkillService
    {
        private readonly IDeveloperSkillRepository _devSkillContext;
        public DeveloperSkillService(IDeveloperSkillRepository appContext)
        {
            _devSkillContext = appContext;
        }

        public void Delete(int id)
        {
            _devSkillContext.Delete(id);
        }

        public DeveloperSkill GetDeveloperSkillById(int id)
        {
            return _devSkillContext.GetDeveloperSkillById(id);
        }

        public List<DeveloperSkill> GetSkillLevelByDevId(int id)
        {
            return _devSkillContext.GetSkillLevelByDevId(id);
        }

        public List<DeveloperSkill> GetSkillLevelBySkillId(int id)
        {
            return _devSkillContext.GetSkillLevelBySkillId(id);
        }

        public void Insert(DeveloperSkill entity)
        {
            _devSkillContext.Insert(entity);
        }
    }
}
