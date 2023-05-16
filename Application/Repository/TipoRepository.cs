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
    public class TipoRepository
    {
        private readonly PokemonContext _context;

        public TipoRepository(PokemonContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Tipos tipo)
        {
            await _context.Tipos.AddAsync(tipo);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Tipos tipo)
        {
            _context.Entry(tipo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Tipos tipo)
        {
            _context.Set<Tipos>().Remove(tipo);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Tipos>> GetAllAsync()
        {
            return await _context.Set<Tipos>().ToListAsync();
        }
        public async Task<Tipos> GetByIdAsync(int Id)
        {
            return await _context.Set<Tipos>().FindAsync(Id);
        }
    }
}
