using System.Collections.Generic;
using System.Threading.Tasks;
using API_TechCycle.Interfaces;
using API_TechCycle.Models;
using Microsoft.EntityFrameworkCore;

namespace TechCycle_Back.Repositorio
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        public async Task<List<Categoria>> Get()
        {
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                return await _context.Categoria.ToListAsync();
            }
        }
        public async Task<Categoria> Get(int id)
        {
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                return await _context.Categoria.FirstOrDefaultAsync(ctg => ctg.IdCategoria == id);
            }
        }
        public async Task<Categoria> Post(Categoria categoria)
        {
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                await _context.Categoria.AddAsync(categoria);
                await _context.SaveChangesAsync();
                return categoria;
            }
        }
        public async Task<Categoria> Put(Categoria categoria)
        {
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                _context.Entry(categoria).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return categoria;
            }
        }
        public async Task<Categoria> Delete(Categoria categoria)
        {
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                _context.Categoria.Remove(categoria);
                await _context.SaveChangesAsync();
                return categoria;
            }
        }
    }
}