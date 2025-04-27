using Application.Repositories;
using Application.ViewModels.Series;
using DB.Contexts;
using DB.Models;


namespace Application.Services
{
    public class SeriesService
    {
        private readonly SeriesRepository _seriesRepository;

        public SeriesService(ApplicationContext dbContext)
        {
            _seriesRepository = new SeriesRepository(dbContext);
        }

        // Método para obtener todas las series como ViewModel
        public async Task<List<SeriesViewModel>> GetAllViewModel()
        {
            var list = await _seriesRepository.GetAllAsync();

            return list.Select(s => new SeriesViewModel
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                ImagePath = s.ImagePath,
                VideoLink = s.VideoLink,

                // IDs para Filtros
                ProductoraId = s.ProductoraId,
                GeneroPrimarioId = s.GeneroPrimarioId,
                GeneroSecundarioId = s.GeneroSecundarioId,

                // Nombres
                Productora = s.Productora.Name,
                GeneroPrimario = s.GeneroPrimario.Name,
                GeneroSecundario = s.GeneroSecundario?.Name
            }).ToList();
        }


        public async Task Add(SaveSeriesViewModel vm)
        {
            var serie = new Serie
            {
                Name = vm.Name,
                Description= vm.Description,
                ImagePath = vm.ImagePath,
                VideoLink = vm.VideoLink,
                ProductoraId = vm.ProductoraId,
                GeneroPrimarioId = vm.GeneroPrimarioId,
                GeneroSecundarioId = vm.GeneroSecundarioId
            };

            await _seriesRepository.AddAsync(serie);
        }


        public async Task<SaveSeriesViewModel> GetByIdSaveViewModel(int id)
        {
            var serie = await _seriesRepository.GetByIdAsync(id);

            if (serie == null) return null;

            return new SaveSeriesViewModel
            {
                Id = serie.Id,
                Name = serie.Name,
                Description = serie.Description,
                ImagePath = serie.ImagePath,
                VideoLink = serie.VideoLink,
                ProductoraId = serie.ProductoraId,
                GeneroPrimarioId = serie.GeneroPrimarioId,
                GeneroSecundarioId = serie.GeneroSecundarioId
            };
        }


        public async Task Update(SaveSeriesViewModel vm)
        {
            var serie = new Serie
            {
                Id = vm.Id,
                Name = vm.Name,
                Description = vm.Description,
                ImagePath = vm.ImagePath,
                VideoLink = vm.VideoLink,
                ProductoraId = vm.ProductoraId,
                GeneroPrimarioId = vm.GeneroPrimarioId,
                GeneroSecundarioId = vm.GeneroSecundarioId
            };

            await _seriesRepository.UpdateAsync(serie);
        }

 
        public async Task Delete(int id)
        {
            var serie = await _seriesRepository.GetByIdAsync(id);
            if (serie != null)
            {
                await _seriesRepository.DeleteAsync(serie);
            }
        }
    }
}
