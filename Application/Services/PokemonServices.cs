using Application.Repository;
using Application.ViewModel.PokemonView;
using Database;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PokemonServices
    {
        private readonly PokemonRepository _pokemonRepository;

        public PokemonServices(PokemonContext context)
        {
            _pokemonRepository = new(context);
        }
        public async Task Update(SavePokemonViewModel vm)
        {
            Pokemon pokemon = new();
            pokemon.Id = vm.Id;
            pokemon.Nombre = vm.Nombre;
            pokemon.TipoId = vm.TipoId;
            pokemon.RegionId = vm.RegionId;

            await _pokemonRepository.UpdateAsync(pokemon);
        }
        public async Task Add(SavePokemonViewModel vm)
        {
            Pokemon pokemon = new();
            pokemon.Id = vm.Id;
            pokemon.Nombre = vm.Nombre;
            pokemon.TipoId = vm.TipoId;
            pokemon.RegionId = vm.RegionId;
            pokemon.ImgUrl = vm.ImgUrl;


            await _pokemonRepository.AddAsync(pokemon);

        }
        public async Task<SavePokemonViewModel> GetByIdSaveViewModel(int id)
        {
            var pokemon = await _pokemonRepository.GetByIdAsync(id);
            SavePokemonViewModel vm = new();
            vm.Id = pokemon.Id;
            vm.Nombre = pokemon.Nombre;
            vm.TipoId = pokemon.TipoId;
            vm.RegionId = pokemon.RegionId;

            return vm;
        }
        public async Task<List<PokemonViewModel>> GetAllViewModel(string nombre = null, int regionId =0)
        {
            var pokemonList = await _pokemonRepository.GetAllAsync();
            var filteredList = pokemonList;

            if (!string.IsNullOrEmpty(nombre))
            {
                var nombreCapitalized = char.ToUpper(nombre[0]) + nombre.Substring(1);
                filteredList = filteredList.Where(p => p.Nombre.Contains(nombreCapitalized)).ToList();
            }
            if(regionId != 0)
            {
                filteredList = filteredList.Where(p=>p.RegionId == regionId).ToList();
            }

            return filteredList.Select(p => new PokemonViewModel
            {
                Nombre = p.Nombre,
                Id = p.Id,
                ImgUrl = p.ImgUrl,
            }).ToList();
        }

        public async Task Delete(int id)
        {
            var product = await _pokemonRepository.GetByIdAsync(id);
            await _pokemonRepository.DeleteAsync(product);
        }
    }
}
