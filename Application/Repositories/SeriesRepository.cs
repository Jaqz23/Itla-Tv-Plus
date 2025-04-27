using DB.Contexts;
using DB.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories
{
    public class SeriesRepository
    {
        private readonly ApplicationContext _dbContext;

        public SeriesRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Serie serie)
        {
            await _dbContext.Set<Serie>().AddAsync(serie);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Serie serie)
        {
            _dbContext.Entry(serie).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Serie serie)
        {
            _dbContext.Set<Serie>().Remove(serie);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Serie>> GetAllAsync()
        {
            return await _dbContext
                .Series
                .Include(s => s.Productora)
                .Include(s => s.GeneroPrimario)
                .Include(s => s.GeneroSecundario)
                .ToListAsync();
        }

        public async Task<Serie> GetByIdAsync(int id)
        {
            return await _dbContext
                .Series
                .Include(s => s.Productora)
                .Include(s => s.GeneroPrimario)
                .Include(s => s.GeneroSecundario)
                .FirstOrDefaultAsync(s => s.Id == id);
        }
    }

}
