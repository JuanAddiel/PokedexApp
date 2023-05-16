using Application.Repository;
using Database.Models;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.TipoView;

namespace Application.Services
{
    public class TipoServices
    {
        private readonly TipoRepository _tipoServices;

        public TipoServices(PokemonContext context)
        {
            _tipoServices = new(context);
        }
        public async Task Update(SaveTipoViewModel vm)
        {
            Tipos tipo = new();
            tipo.Id = vm.Id;
            tipo.Nombre = vm.Nombre;

            await _tipoServices.UpdateAsync(tipo);
        }
        public async Task Add(SaveTipoViewModel vm)
        {
            Tipos tipo = new();
            tipo.Id = vm.Id;
            tipo.Nombre = vm.Nombre;

            await _tipoServices.AddAsync(tipo);
        }
        public async Task<SaveTipoViewModel> GetByIdSaveViewModel(int id)
        {
            var tipo = await _tipoServices.GetByIdAsync(id);
            SaveTipoViewModel vm = new();
            vm.Id = tipo.Id;
            vm.Nombre = tipo.Nombre;

            return vm;
        }
        public async Task<List<TipoViewModel>> GetAllViewModel()
        {
            var tipoList = await _tipoServices.GetAllAsync();
            return tipoList.Select(p => new TipoViewModel
            {
                Nombre = p.Nombre,
                Id = p.Id,
            }).ToList();
        }

        public async Task Delete(int id)
        {
            var tipo = await _tipoServices.GetByIdAsync(id);
            await _tipoServices.DeleteAsync(tipo);
        }
    }
}
