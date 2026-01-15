

using Microsoft.EntityFrameworkCore;

namespace EcoCheck.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public IQueryable<T> GetAll();
        public Task<T> GetById(int id);
        public  Task Create(T entity);
        public Task CreateRange(IEnumerable<T> entity);
        
        public Task Update(T entity);
        public Task Delete(T entity);

    }
}
