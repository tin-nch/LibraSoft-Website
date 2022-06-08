
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Librasoft_API.Librasoft.DataAccess.Repositorys.Constracts
{
    public interface IRepository<TEntity> where TEntity : class
    {
     

        Task<IReadOnlyList<TEntity>> ListAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<TEntity> DeleteAsync(TEntity entity);

        Task<int> CountAsync(Expression<Func<TEntity, bool>> filter = null);
        

    }
}
