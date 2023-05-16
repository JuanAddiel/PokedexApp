using Database;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class PokemonRepository
    {
        private readonly PokemonContext _context;

        public PokemonRepository(PokemonContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Pokemon pokemon)
        {
            await _context.Pokemon.AddAsync(pokemon);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Pokemon pokemon)
        {
            _context.Entry(pokemon).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Pokemon pokemon)
        {
            _context.Set<Pokemon>().Remove(pokemon);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Pokemon>> GetAllAsync()
        {
            return await _context.Set<Pokemon>().ToListAsync();
        }
        public async Task<Pokemon> GetByIdAsync(int Id)
        {
            return await _context.Set<Pokemon>().FindAsync(Id);
        }
        public async Task<Pokemon> GetByNameAsync(string nombre)
        {
            return await _context.Set<Pokemon>().FindAsync(nombre);
        }
    }
}
