using Dev.Business.Services;
using Microsoft.EntityFrameworkCore;
using ModelBindingDemo.Data;
using Dev.Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace ModelBindingDemo.Repository
{
    public class DeveloperService : IDeveloperService
    {
        private readonly IDeveloperRepository _devContext;
        public DeveloperService(IDeveloperRepository appContext)
        {
            _devContext = appContext;
        }

        public void Delete(int id)
        {
            _devContext.Delete(id);
        }

        public List<Developer> GetAllDevelopers()
        {
            return _devContext.GetAllDevelopers();
        }

        public Developer GetDeveloperById(int id)
        {
            return _devContext.GetDeveloperById(id);
        }

        public void Insert(Developer entity)
        {
            _devContext.Insert(entity);
        }

        public void Update(Developer developer)
        {
            _devContext.Update(developer);
        }
    }
}
