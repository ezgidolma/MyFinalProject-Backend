using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> Getall(Expression<Func<T,bool>> filtre=null);
        T Get(Expression<Func<T, bool>> filtre);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
