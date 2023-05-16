using Application.Services;
using Application.ViewModel.RegionView;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace Pokemon.Controllers
{
    public class RegionController : Controller
    {
        private readonly RegionServices _regionServices;
        public RegionController(PokemonContext context)
        {
            _regionServices = new(context);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _regionServices.GetAllViewModel());
        }

        public IActionResult Create()
        {
            return View("SaveRegion", new SaveRegionViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(SaveRegionViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveRegion", vm);
            }
            await _regionServices.Add(vm);
            return RedirectToRoute(new { controller = "Region", action = "Index" });
        }
        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveRegion", await _regionServices.GetByIdSaveViewModel(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SaveRegionViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveRegion", vm);
            }
            await _regionServices.Update(vm);
            return RedirectToRoute(new { controller = "Region", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View("Delete", await _regionServices.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _regionServices.Delete(id);
            return RedirectToRoute(new { controller = "Region", action = "Index" });
        }
    }
}
