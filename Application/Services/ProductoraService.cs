using Application.Repositories;
using Application.ViewModels.Productora;
using DB.Contexts;
using DB.Models;

namespace Application.Services
{
    public class ProductoraService
    {
        private readonly ProductoraRepository _repository;

        public ProductoraService(ApplicationContext dbContext)
        {
            _repository = new ProductoraRepository(dbContext);
        }

        public async Task<List<ProductoraViewModel>> GetAllViewModel()
        {
            var list = await _repository.GetAllAsync();
            return list.Select(p => new ProductoraViewModel
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();
        }

        public async Task Add(SaveProductoraViewModel vm)
        {
            var productora = new Productora
            {
                Name = vm.Name
            };

            await _repository.AddAsync(productora);
        }

        public async Task<SaveProductoraViewModel> GetByIdSaveViewModel(int id)
        {
            var productora = await _repository.GetByIdAsync(id);

            return new SaveProductoraViewModel
            {
                Id = productora.Id,
                Name = productora.Name
            };
        }

        public async Task Update(SaveProductoraViewModel vm)
        {
            var productora = new Productora
            {
                Id = vm.Id,
                Name = vm.Name
            };

            await _repository.UpdateAsync(productora);
        }

        public async Task Delete(int id)
        {
            var productora = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(productora);
        }
    }

}
