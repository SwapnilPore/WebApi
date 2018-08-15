using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.DataAccess.Database.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Edit(TEntity entity);
        void Save();
    }
}
