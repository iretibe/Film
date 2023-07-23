using Film.Core.Entities;
using Film.Core.Repositories;
using Film.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Film.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        public FilmDbContext _context { get; }

        public Repository(FilmDbContext context)
        {
            _context = context;
        }        

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);

            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}
