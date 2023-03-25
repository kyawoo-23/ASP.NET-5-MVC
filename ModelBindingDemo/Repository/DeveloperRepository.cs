using Microsoft.EntityFrameworkCore;
using ModelBindingDemo.Data;
using ModelBindingDemo.Models;
using System.Collections.Generic;
using System.Linq;

namespace ModelBindingDemo.Repository
{
    public class DeveloperRepository : IDeveloperRepository
    {
        private readonly AppDbContext _appContext;
        public DeveloperRepository(AppDbContext appContext)
        {
            _appContext = appContext;
        }

        public void Delete(int id)
        {
            Developer data = _appContext.Developers.FirstOrDefault(x => x.DeveloperId == id);
            _appContext.Developers.Remove(data);
        }

        public List<Developer> GetAllDevelopers()
        {
            return _appContext.Developers.ToList();
        }

        public Developer GetDeveloperById(int id)
        {
            Developer dev = _appContext.Developers
                .Where(d => d.DeveloperId == id)
                .Include(s => s.Notes)
                .FirstOrDefault(d => d.DeveloperId == id);
            return dev;
        }

        public void Insert(Developer developer)
        {
            _appContext.Add(developer);
        }

        public void Save()
        {
            _appContext.SaveChanges();
        }

        public void Update(Developer developer)
        {
            _appContext.Entry(developer).State = EntityState.Modified;
        }
    }
}
