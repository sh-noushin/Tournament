using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Tournament.API.Domain.Core
{
    public interface IBaseRepository<TModel, TId>
       where TModel : BaseEntity<TId>      
    {
        Task CreateAsync(TModel model);
        Task UpdateAsync(TModel model);
        Task DeleteAsync(TModel model);
        Task<TId> DeleteAsync(TId id);
        Task<TModel> GetAsync(TId id, params Expression<Func<TModel, object>>[] includes);
        Task<List<TModel>> GetListAsync(params Expression<Func<TModel, object>>[] includes);
        Task<List<TModel>> GetListAsync(Expression<Func<TModel, bool>> expression, params Expression<Func<TModel, object>>[] includes);
        Task<bool> AnyAsync(Expression<Func<TModel, bool>> expression);
        Task<TModel> FindAsync(TId id, params Expression<Func<TModel, object>>[] includes);
        Task<TModel> FindAsync(TId id);
        Task<TModel> FindAsync(Expression<Func<TModel, bool>> expression);
        Task<IQueryable<TModel>> QueryableAsync();
    }
}
