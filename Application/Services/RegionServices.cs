using Application.Repository;
using Database.Models;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.RegionView;

namespace Application.Services
{
    public class RegionServices
    {
        private readonly RegionRepository _regionServices;

        public RegionServices(PokemonContext context)
        {
            _regionServices = new(context);
        }
        public async Task Update(SaveRegionViewModel vm)
        {
            Region region = new();
            region.Id = vm.Id;
            region.Nombre = vm.Nombre;

            await _regionServices.UpdateAsync(region);
        }
        public async Task Add(SaveRegionViewModel vm)
        {
            Region region = new();
            region.Id = vm.Id;
            region.Nombre = vm.Nombre;

            await _regionServices.AddAsync(region);
        }
        public async Task<SaveRegionViewModel> GetByIdSaveViewModel(int id)
        {
            var region = await _regionServices.GetByIdAsync(id);
            SaveRegionViewModel vm = new();
            vm.Id = region.Id;
            vm.Nombre = region.Nombre;

            return vm;
        }
        public async Task<List<RegionViewModel>> GetAllViewModel()
        {
            var regionList = await _regionServices.GetAllAsync();
            return regionList.Select(p => new RegionViewModel
            {
                Nombre = p.Nombre,
                Id = p.Id,
            }).ToList();
        }

        public async Task Delete(int id)
        {
            var region = await _regionServices.GetByIdAsync(id);
            await _regionServices.DeleteAsync(region);
        }
    }
}
