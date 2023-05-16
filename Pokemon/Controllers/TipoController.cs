using Application.Services;
using Application.ViewModel.TipoView;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace Pokemon.Controllers
{
    public class TipoController : Controller
    {
        private readonly TipoServices _tipoServices;
        public TipoController(PokemonContext context)
        {
            _tipoServices = new(context);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _tipoServices.GetAllViewModel());
        }

        public IActionResult Create()
        {
            return View("SaveTipo", new SaveTipoViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(SaveTipoViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveTipo", vm);
            }
            await _tipoServices.Add(vm);
            return RedirectToRoute(new { controller = "Tipo", action = "Index" });
        }
        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveTipo", await _tipoServices.GetByIdSaveViewModel(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SaveTipoViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveTipo", vm);
            }
            await _tipoServices.Update(vm);
            return RedirectToRoute(new { controller = "Tipo", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View("Delete", await _tipoServices.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _tipoServices.Delete(id);
            return RedirectToRoute(new { controller = "Tipo", action = "Index" });
        }
    }
}
