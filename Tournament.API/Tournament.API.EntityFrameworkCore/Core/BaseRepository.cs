using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Tournament.API.Domain.Core;
using Tournament.API.Domain.Core.Exceptions;

namespace Tournament.API.EntityFrameworkCore.Core
{
    public abstract class BaseRepository<TDbContext, TModel, TId> : IBaseRepository<TModel, TId>
        where TDbContext : DbContext
        where TModel : BaseEntity<TId>
       
    {
        protected readonly TDbContext Db;

        protected BaseRepository(TDbContext db)
        {
            Db = db;

        }

        public async Task CreateAsync(TModel model)
        {
            await Db.Set<TModel>().AddAsync(model);
            await Db.SaveChangesAsync();
        }


        public async Task<TModel> GetAsync(TId id, params Expression<Func<TModel, object>>[] includes)
        {
            var query = Db.Set<TModel>().AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            var model = await query.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (model == null)
            {
                throw new EntityNotFoundException();
            }
            return model;   
        }


        public async Task<List<TModel>> GetListAsync(params Expression<Func<TModel, object>>[] includes)
        {
            var query = Db.Set<TModel>().AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.ToListAsync();
            
        }



        public async Task<List<TModel>> GetListAsync(Expression<Func<TModel, bool>> expression, params Expression<Func<TModel, object>>[] includes)
        {
            var query = Db.Set<TModel>().AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.Where(expression).ToListAsync();

        }



        public async Task<TModel> FindAsync(TId id, params Expression<Func<TModel, object>>[] includes)
        {
            var query = Db.Set<TModel>().AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(x => x.Id.Equals(id));

        }

        public async Task<TModel> FindAsync(TId id)
        {
            return await Db.Set<TModel>().FindAsync(id);

        }

        public async Task<TModel> FindAsync(Expression<Func<TModel, bool>> expression)
        {
            return await Db.Set<TModel>().FindAsync(expression);
        }




        public async Task<bool> AnyAsync(Expression<Func<TModel, bool>> expression)
        {
            return await Db.Set<TModel>().AnyAsync(expression);
        }



        public async Task UpdateAsync(TModel model)
        {
            Db.Entry(model).State = EntityState.Modified;
            await Db.SaveChangesAsync();
        }




        public async Task DeleteAsync(TModel model)
        {
            Db.Set<TModel>().Remove(model);
            await Db.SaveChangesAsync();
        }



        public async Task<TId> DeleteAsync(TId id)
        {
            var model = await Db.Set<TModel>().FindAsync(id);
            if (model != null)
            {
                Db.Set<TModel>().Remove(model);
                await Db.SaveChangesAsync();
            }

            return id;

        }



        public Task<IQueryable<TModel>> QueryableAsync()
        {
            return Task.FromResult(Db.Set<TModel>().AsQueryable());
        }


    }
}
