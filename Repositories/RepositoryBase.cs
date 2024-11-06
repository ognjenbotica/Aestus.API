using Aestus.API.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Aestus.API.Repositories
{
    public abstract class RepositoryBase<TContext, T> : IRepositoryBase<T> where T : class where TContext : DbContext
    {
        protected TContext _context;
        protected DbSet<T> _dbSet;

        public RepositoryBase(TContext context)
        {
            this._context = context;
            this._dbSet = context.Set<T>();
        }

        public async Task<List<T>> FindAllAsync(bool trackChanges)
        {
            return await (!trackChanges ?
                _dbSet.AsNoTracking().ToListAsync() :
                _dbSet.ToListAsync());
        }

        public async Task<List<T>> FindByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return await (!trackChanges ?
                _dbSet
                .Where(expression)
                .AsNoTracking().ToListAsync() :
                _dbSet
                .Where(expression).ToListAsync());
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await GetAsync(id);

            if (entity == null)
            {
                return;
            }

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T?> GetAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await GetAsync(id);
            return entity != null;
        }
    }
}



