using System.Collections.Generic;
using System.Threading.Tasks;
using API_TechCycle.Interfaces;
using API_TechCycle.Models;
using Microsoft.EntityFrameworkCore;

namespace TechCycle_Back.Repositorio
{
    public class AvaliacaoRepositorio : IAvaliacaoRepositorio
    {
        public async Task<List<Avaliacao>> Get()
        {
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                return await _context.Avaliacao.ToListAsync();
            }
        }
        public async Task<Avaliacao> Get(int id)
        {
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                return await _context.Avaliacao.FirstOrDefaultAsync(avl => avl.IdAvaliacao == id);
            }
        }
        public async Task<Avaliacao> Post(Avaliacao avaliacao)
        {
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                await _context.Avaliacao.AddAsync(avaliacao);
                await _context.SaveChangesAsync();
                return avaliacao;
            }
        }
        public async Task<Avaliacao> Put(Avaliacao avaliacao)
        {
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                _context.Entry(avaliacao).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return avaliacao;
            }
        }
        public async Task<Avaliacao> Delete(Avaliacao avaliacao)
        {
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                _context.Avaliacao.Remove(avaliacao);
                await _context.SaveChangesAsync();
                return avaliacao;
            }
        }
    }
}