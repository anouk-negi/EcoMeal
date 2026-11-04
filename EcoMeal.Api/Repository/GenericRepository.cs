using EcoMeal.Api.Data;
using EcoMeal.Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcoMeal.Api.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly EcoMealDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(EcoMealDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task InsertAsync(T Entity)
        {
            await _dbSet.AddAsync(Entity);
        }

        public async Task UpdateAsync(T Entity)
        {

            _dbSet.Update(Entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if(entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
