using Application.Services;
using Application.ViewModels.Productora;
using DB.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace Itla_Tv_.Controllers
{
    public class ProductoraController : Controller
    {
        private readonly ProductoraService _service;

        public ProductoraController(ApplicationContext dbContext)
        {
            _service = new ProductoraService(dbContext);
        }

        // Listado de Productoras
        public async Task<IActionResult> Index()
        {
            var list = await _service.GetAllViewModel();
            return View(list);
        }

        // Crear nueva productora
        public IActionResult Create()
        {
            return View("SaveProductora", new SaveProductoraViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveProductoraViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveProductora", vm);
            }

            await _service.Add(vm);
            return RedirectToAction("Index");
        }

        // Editar productora
        public async Task<IActionResult> Edit(int id)
        {
            var vm = await _service.GetByIdSaveViewModel(id);
            if (vm == null)
            {
                return NotFound();
            }

            return View("SaveProductora", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveProductoraViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveProductora", vm);
            }

            await _service.Update(vm);
            return RedirectToAction("Index");
        }

        // Eliminar productora
        public async Task<IActionResult> Delete(int id)
        {
            var vm = await _service.GetByIdSaveViewModel(id);
            if (vm == null)
            {
                return NotFound();
            }

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
