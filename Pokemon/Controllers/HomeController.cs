using Application.Services;
using Database;
using Microsoft.AspNetCore.Mvc;
using Pokemon.Models;
using System.Diagnostics;

namespace Pokemon.Controllers
{
    public class HomeController : Controller
    {
        private readonly PokemonServices _pokemonServices;

        public HomeController(PokemonContext context)
        {
            _pokemonServices = new(context);
        }

        public async Task<IActionResult> Index(string nombre, int regionId)
        {
            return View(await _pokemonServices.GetAllViewModel(nombre, regionId));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}