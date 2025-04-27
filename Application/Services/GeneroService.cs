using Application.Repositories;
using Application.ViewModels.Genero;
using DB.Contexts;
using DB.Models;


namespace Application.Services
{
    public class GeneroService
    {
        private readonly GeneroRepository _repository;

        public GeneroService(ApplicationContext dbContext)
        {
            _repository = new GeneroRepository(dbContext);
        }

        public async Task<List<GeneroViewModel>> GetAllViewModel()
        {
            var list = await _repository.GetAllAsync();
            return list.Select(g => new GeneroViewModel
            {
                Id = g.Id,
                Name = g.Name
            }).ToList();
        }

        public async Task Add(SaveGeneroViewModel vm)
        {
            var genero = new Genero
            {
                Name = vm.Name
            };

            await _repository.AddAsync(genero);
        }

        public async Task<SaveGeneroViewModel> GetByIdSaveViewModel(int id)
        {
            var genero = await _repository.GetByIdAsync(id);

            return new SaveGeneroViewModel
            {
                Id = genero.Id,
                Name = genero.Name
            };
        }

        public async Task Update(SaveGeneroViewModel vm)
        {
            var genero = new Genero
            {
                Id = vm.Id,
                Name = vm.Name
            };

            await _repository.UpdateAsync(genero);
        }

        public async Task Delete(int id)
        {
            var genero = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(genero);
        }
    }
}
