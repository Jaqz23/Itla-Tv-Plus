using DB.Contexts;
using DB.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories
{
    public class GeneroRepository
    {
        private readonly ApplicationContext _dbContext;

        public GeneroRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Genero genero)
        {
            await _dbContext.Set<Genero>().AddAsync(genero);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Genero genero)
        {
            _dbContext.Entry(genero).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Genero genero)
        {
            _dbContext.Set<Genero>().Remove(genero);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Genero>> GetAllAsync()
        {
            return await _dbContext.Generos.ToListAsync();
        }

        public async Task<Genero> GetByIdAsync(int id)
        {
            return await _dbContext.Generos.FindAsync(id);
        }
    }
}
