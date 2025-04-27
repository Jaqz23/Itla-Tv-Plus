using Application.Services;
using DB.Contexts;
using Microsoft.AspNetCore.Mvc;
using Application.ViewModels.Series;

namespace Itla_Tv_.Controllers
{
    public class SeriesController : Controller
    {
        private readonly SeriesService _seriesService;
        private readonly ProductoraService _productoraService;
        private readonly GeneroService _generoService;

        public SeriesController(ApplicationContext dbContext)
        {
            _seriesService = new SeriesService(dbContext);
            _productoraService = new ProductoraService(dbContext);
            _generoService = new GeneroService(dbContext);
        }

        // Listado de series
        public async Task<IActionResult> Index()
        {
            var list = await _seriesService.GetAllViewModel();
            return View(list);
        }

        // Crear nueva serie
        public async Task<IActionResult> Create()
        {
            var vm = new SaveSeriesViewModel
            {
                Productoras = await _productoraService.GetAllViewModel(),
                Generos = await _generoService.GetAllViewModel()
            };
            return View("SaveSeries", vm);
        }

        
        [HttpPost]
        public async Task<IActionResult> Create(SaveSeriesViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Productoras = await _productoraService.GetAllViewModel();
                vm.Generos = await _generoService.GetAllViewModel();
                return View("SaveSeries", vm);
            }

            await _seriesService.Add(vm);
            return RedirectToAction("Index");
        }

        // Editar serie
        public async Task<IActionResult> Edit(int id)
        {
            var vm = await _seriesService.GetByIdSaveViewModel(id);
            if (vm == null)
            {
                return NotFound();
            }

            vm.Productoras = await _productoraService.GetAllViewModel();
            vm.Generos = await _generoService.GetAllViewModel();
            return View("SaveSeries", vm);
        }

        
        [HttpPost]
        public async Task<IActionResult> Edit(SaveSeriesViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Productoras = await _productoraService.GetAllViewModel();
                vm.Generos = await _generoService.GetAllViewModel();
                return View("SaveSeries", vm);
            }

            await _seriesService.Update(vm);
            return RedirectToAction("Index");
        }

       
        // Eliminar serie
        public async Task<IActionResult> Delete(int id)
        {
            var vm = await _seriesService.GetByIdSaveViewModel(id);
            if (vm == null)
            {
                return NotFound();
            }

            return View(vm);
        }

        
        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _seriesService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
