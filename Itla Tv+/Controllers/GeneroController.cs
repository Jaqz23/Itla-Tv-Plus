using Application.Services;
using Application.ViewModels.Genero;
using DB.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace Itla_Tv_.Controllers
{
    public class GeneroController : Controller
    {
        private readonly GeneroService _service;

        public GeneroController(ApplicationContext dbContext)
        {
            _service = new GeneroService(dbContext);
        }

        // Listado de Generos
        public async Task<IActionResult> Index()
        {
            var list = await _service.GetAllViewModel();
            return View(list);
        }

        // Crear nuevo genero
        public IActionResult Create()
        {
            return View("SaveGenero", new SaveGeneroViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveGeneroViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveGenero", vm);
            }

            await _service.Add(vm);
            return RedirectToAction("Index");
        }

        // Editar genero
        public async Task<IActionResult> Edit(int id)
        {
            var vm = await _service.GetByIdSaveViewModel(id);
            if (vm == null)
            {
                return NotFound();
            }

            return View("SaveGenero", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveGeneroViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveGenero", vm);
            }

            await _service.Update(vm);
            return RedirectToAction("Index");
        }

        // Eliminar genero
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
