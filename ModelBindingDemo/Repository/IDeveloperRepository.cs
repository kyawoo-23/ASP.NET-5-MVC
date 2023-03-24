using ModelBindingDemo.Models;
using System.Collections.Generic;

namespace ModelBindingDemo.Repository
{
    public interface IDeveloperRepository
    {
        List<Developer> GetAllDevelopers();
        Developer GetDeveloperById(int id);
        void Insert(Developer developer);
        void Update(Developer developer);
        void Delete(int id);
        void Save();

    }
}
