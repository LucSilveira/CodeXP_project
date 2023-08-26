using System.Collections.Generic;
using System.Threading.Tasks;
using API_TechCycle.Interfaces;
using API_TechCycle.Models;
using Microsoft.EntityFrameworkCore;

namespace API_TechCycle.Repositorio
{
    public class FotosAnuncioRepositorio : IFotosAnuncioRepositorio
    {
        public async Task<List<FotosAnuncio>> Get()
        {
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                return await _context.FotosAnuncio.ToListAsync();
            }
        }
        public async Task<FotosAnuncio> Get(int id)
        {
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                return await _context.FotosAnuncio.FirstOrDefaultAsync(fts => fts.IdFotosAnuncio == id);
            }
        }
        public async Task<FotosAnuncio> Post(FotosAnuncio fotosAnuncio)
        {
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                await _context.FotosAnuncio.AddAsync(fotosAnuncio);
                await _context.SaveChangesAsync();
                return fotosAnuncio;
            }
        }
        public async Task<FotosAnuncio> Put(FotosAnuncio fotosAnuncio)
        {
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                _context.Entry(fotosAnuncio).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return fotosAnuncio;
            }
        }
        public async Task<FotosAnuncio> Delete(FotosAnuncio fotosAnuncio)
        {
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                _context.FotosAnuncio.Remove(fotosAnuncio);
                await _context.SaveChangesAsync();
                return fotosAnuncio;
            }
        }
    }
}