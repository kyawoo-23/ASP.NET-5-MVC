using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Business.Services
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        void Insert(TEntity entity);
        void Delete(int id);
    }
}
