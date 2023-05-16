using Database.Models;
using Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class RegionRepository
    {
        private readonly PokemonContext _context;

        public RegionRepository(PokemonContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Region region)
        {
            await _context.Region.AddAsync(region);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Region region)
        {
            _context.Entry(region).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Region region)
        {
            _context.Set<Region>().Remove(region);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await _context.Set<Region>().ToListAsync();
        }
        public async Task<Region> GetByIdAsync(int Id)
        {
            return await _context.Set<Region>().FindAsync(Id);
        }
    }
}
