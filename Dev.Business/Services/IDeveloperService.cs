using Dev.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Business.Services
{
    public interface IDeveloperService : IBaseService<Developer>
    {
        List<Developer> GetAllDevelopers();
        Developer GetDeveloperById(int id);
        void Update(Developer developer);
    }
}
