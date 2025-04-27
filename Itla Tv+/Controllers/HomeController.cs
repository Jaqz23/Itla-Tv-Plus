using Application.Services;
using DB.Contexts;
using Microsoft.AspNetCore.Mvc;


namespace Itla_Tv_.Controllers 
{
    public class HomeController : Controller
    {
        private readonly SeriesService _seriesService;
        private readonly ProductoraService _productoraService;
        private readonly GeneroService _generoService;

        public HomeController(ApplicationContext dbContext)
        {
            _seriesService = new SeriesService(dbContext);
            _productoraService = new ProductoraService(dbContext);
            _generoService = new GeneroService(dbContext);
        }

        public async Task<IActionResult> Index(string search, int? productoraId, int? generoId, string sortOrder)
        {
            var seriesViewModel = await _seriesService.GetAllViewModel();

            // Filtro por nombre
            if (!string.IsNullOrEmpty(search))
            {
                seriesViewModel = seriesViewModel
                    .Where(s => s.Name.Contains(search, System.StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            // Filtro por productora
            if (productoraId.HasValue)
            {
                seriesViewModel = seriesViewModel
                    .Where(s => s.ProductoraId == productoraId)
                    .ToList();
            }

            // Filtro por genero (genero principal o secundario)
            if (generoId.HasValue)
            {
                seriesViewModel = seriesViewModel
                    .Where(s => s.GeneroPrimarioId == generoId || s.GeneroSecundarioId == generoId)
                    .ToList();
            }

            // Ordenamiento
            seriesViewModel = sortOrder switch
            {
                "name" => seriesViewModel.OrderBy(s => s.Name).ToList(),
                "productora" => seriesViewModel.OrderBy(s => s.Productora).ToList(),
                "genero" => seriesViewModel.OrderBy(s => s.GeneroPrimario).ToList(),
                _ => seriesViewModel
            };

            // Pasar listas de Productoras y Generos a la Vista
            ViewBag.Productoras = await _productoraService.GetAllViewModel();
            ViewBag.Generos = await _generoService.GetAllViewModel();

            return View(seriesViewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var series = await _seriesService.GetAllViewModel();
            var serieDetails = series.FirstOrDefault(s => s.Id == id);

            if (serieDetails == null)
            {
                return NotFound();
            }

            return View(serieDetails);
        }
    }

}
