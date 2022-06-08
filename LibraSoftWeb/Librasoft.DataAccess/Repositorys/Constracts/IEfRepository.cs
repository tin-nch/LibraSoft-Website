


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Librasoft_API.Librasoft.DataAccess.Repositorys.Constracts
{
    public interface IEfRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        Task<int> CountAsync(Expression<Func<TEntity, bool>> filter = null);

     
    }
}
