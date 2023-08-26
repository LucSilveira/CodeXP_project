using System.Collections.Generic;
using System.Threading.Tasks;
using API_TechCycle.Interfaces;
using API_TechCycle.Models;
using Microsoft.EntityFrameworkCore;

namespace TechCycle_Back.Repositorio
{
    public class MarcaRepositorio : IMarcaRepositorio
    {
        public async Task<List<Marca>> Get()
        {
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                return await _context.Marca.ToListAsync();
            }
        }
        public async Task<Marca> Get(int id)
        {
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                return await _context.Marca.FirstOrDefaultAsync(mrc => mrc.IdMarca == id);
            }
        }
        public async Task<Marca> Post(Marca marca)
        {
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                await _context.Marca.AddAsync(marca);
                await _context.SaveChangesAsync();
                return marca;
            }
        }
        public async Task<Marca> Put(Marca marca)
        {
           using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                _context.Entry(marca).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return marca;
            }
        }
        public async Task<Marca> Delete(Marca marca)
        {
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                _context.Marca.Remove(marca);
                await _context.SaveChangesAsync();

                return marca;
            }
        }
    }
}