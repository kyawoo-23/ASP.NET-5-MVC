using Dev.DataAccess.Repositories;
using Dev.Entities.Models;
using System.Collections.Generic;

namespace ModelBindingDemo.Repository
{
    public interface IDeveloperRepository : IBaseRepository<Developer>
    {
        List<Developer> GetAllDevelopers();
        Developer GetDeveloperById(int id);
        void Update(Developer developer);
    }
}
