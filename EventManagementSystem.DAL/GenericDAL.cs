using Microsoft.EntityFrameworkCore;

namespace EventManagementSystem.DAL
{
    public class GenericDAL<M, C> : IGenericDAL<M> where M : class where C : DbContext
    {
        protected readonly C _dbContext;
        protected readonly DbSet<M> _dbSet;

        public GenericDAL(C dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<M>();
        }

        public async Task<List<M>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<List<M>> FilterAsync(Func<IQueryable<M>, IQueryable<M>> query)
        {
            return await query(_dbSet).ToListAsync();
        }

        public async Task<M?> GetAsync<I>(I id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(M m)
        {
            await _dbSet.AddAsync(m);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(M m)
        {
            _dbSet.Update(m);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(M m)
        {
            _dbSet.Remove(m);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync<I>(I id)
        {
            var m = await GetAsync(id);
            await RemoveAsync(m);
        }

        // Synchronous wrappers for methods if needed
        public List<M> GetAll()
        {
            return GetAllAsync().Result;
        }

        public List<M> Filter(Func<IQueryable<M>, IQueryable<M>> query)
        {
            return FilterAsync(query).Result;
        }

        public M? Get<I>(I id)
        {
            return GetAsync(id).Result;
        }

        public void Add(M m)
        {
            AddAsync(m).Wait();
        }

        public void Update(M m)
        {
            UpdateAsync(m).Wait();
        }

        public void Remove(M m)
        {
            RemoveAsync(m).Wait();
        }

        public void Remove<I>(I id)
        {
            RemoveAsync<I>(id).Wait();
        }
    }
}
