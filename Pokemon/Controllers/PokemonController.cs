using Application.Services;
using Application.ViewModel.PokemonView;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace Pokemon.Controllers
{
    public class PokemonController : Controller
    {
        private readonly PokemonServices _pokemonServices;
        public PokemonController(PokemonContext context)
        {
            _pokemonServices = new(context);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _pokemonServices.GetAllViewModel());
        }

        public IActionResult Create()
        {
            return View("SavePokemon", new SavePokemonViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(SavePokemonViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SavePokemon", vm);
            }
            await _pokemonServices.Add(vm);
            return RedirectToRoute(new { controller = "Pokemon", action = "Index" });
        }
        public async Task<IActionResult> Edit(int id)
        {
            return View("SavePokemon", await _pokemonServices.GetByIdSaveViewModel(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SavePokemonViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SavePokemon", vm);
            }
            await _pokemonServices.Update(vm);
            return RedirectToRoute(new { controller = "Pokemon", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View("Delete", await _pokemonServices.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _pokemonServices.Delete(id);
            return RedirectToRoute(new { controller = "Pokemon", action = "Index" });
        }
    }
}
