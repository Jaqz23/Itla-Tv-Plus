using DB.Contexts;
using DB.Models;
using Microsoft.EntityFrameworkCore;


namespace Application.Repositories
{
    public class ProductoraRepository
    {
        private readonly ApplicationContext _dbContext;

        public ProductoraRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Productora productora)
        {
            await _dbContext.Set<Productora>().AddAsync(productora);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Productora productora)
        {
            _dbContext.Entry(productora).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Productora productora)
        {
            _dbContext.Set<Productora>().Remove(productora);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Productora>> GetAllAsync()
        {
            return await _dbContext.Productoras.ToListAsync();
        }

        public async Task<Productora> GetByIdAsync(int id)
        {
            return await _dbContext.Productoras.FindAsync(id);
        }
    }

}
