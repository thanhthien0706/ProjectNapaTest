using Microsoft.EntityFrameworkCore;
using Napa.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UdemyWeb.DataAccess.Repository.IRepository;

namespace UdemyWeb.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public readonly DbContextApplication _dbContext;
        internal DbSet<T> dbSet;

        public Repository(DbContextApplication dbContext)
        {
            _dbContext = dbContext;
            this.dbSet = _dbContext.Set<T>();
        }

        public async Task Add(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async Task<T?> Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            IQueryable<T> query = dbSet;

            return await query.ToListAsync();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}
