using ModelBindingDemo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.DataAccess.Repositories.Implementation
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        public void Delete(int id)
        {
            using var context = new AppDbContext();
            TEntity data = context.Set<TEntity>().Find(id);
            context.Remove(data);
            context.SaveChanges();
        }

        public List<TEntity> GetAll()
        {
            using var context = new AppDbContext();
            return context.Set<TEntity>().ToList();
        }

        public virtual void Insert(TEntity entity)
        {
            using var context = new AppDbContext();
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }
    }
}
