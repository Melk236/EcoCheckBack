

using EcoCheck.Domain.Interfaces;
using EcoCheck.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EcoCheck.Infrastructure.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;
        private readonly AppDbContext _context;
        public GenericRepository(AppDbContext context) { 
        
            _dbSet = context.Set<T>();
            _context = context;
        }

        public  IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking();
        }

        public async Task<T> GetById(int id)
        {
            var entity=await _dbSet.FindAsync(id);
        
            return entity;
        }

        public virtual async Task Create(T entity)
        {
             _dbSet.Add(entity);

            await _context.SaveChangesAsync(); 

           
        }
        public async Task CreateRange(IEnumerable<T> entity)
        {
            _dbSet.AddRange(entity);

            await _context.SaveChangesAsync();


        }

        public async Task Update(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();

            
        }

        public async Task Delete(T entity)
        {
            
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
                    

        }
    }
}
