using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_TechCycle.Interfaces;
using API_TechCycle.Models;
using Microsoft.EntityFrameworkCore;

namespace API_TechCycle.Repositorio
{
    public class InteresseRepositorio : IInteresseRepositorio
    {
        public async Task<List<Interesse>> Get()
        {
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                return await _context.Interesse.ToListAsync();
            }
        }
        public async Task<Interesse> Get(int id)
        {
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                return await _context.Interesse.FirstOrDefaultAsync(itr => itr.IdInteresse == id);
            }
        }
        public async Task<List<Interesse>> GetPorStatus(string statusAprovacao)
        {
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                List<Interesse> listaInteressesStatus =
                    await _context.Interesse.Where(itr => itr.StatusAprovacao == statusAprovacao)
                        .Include("IdUsuarioInteressadoNavigation").Include("IdAnuncioNavigation")
                            .ToListAsync();

                return listaInteressesStatus;
            }
        }
        public async Task<List<Interesse>> GetPorAnuncio(int idAnuncio)
        {
            List<Interesse> listaInteresseAnuncio;
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                listaInteresseAnuncio = await _context.Interesse
                    .Where(itr => itr.IdAnuncio == idAnuncio && itr.StatusAprovacao != "Aprovado")
                        .Include("IdUsuarioInteressadoNavigation").Include("IdAnuncioNavigation")
                            .ToListAsync();

                foreach(var interesseAnuncio in listaInteresseAnuncio)
                {
                    interesseAnuncio.IdAnuncioNavigation.Interesse = null;
                    interesseAnuncio.IdUsuarioAprovacaoNavigation = null;
                    interesseAnuncio.IdUsuarioInteressadoNavigation
                        .InteresseIdUsuarioInteressadoNavigation = null;
                    interesseAnuncio.IdUsuarioInteressadoNavigation
                        .InteresseIdUsuarioAprovacaoNavigation = null;
                }

                return listaInteresseAnuncio;
            }
        }
        public async Task<Interesse> Post(Interesse interesse)
        {
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                await _context.Interesse.AddAsync(interesse);
                await _context.SaveChangesAsync();
                return interesse;
            }
        }
        public async Task<Interesse> Put(Interesse interesse)
        {
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                _context.Entry(interesse).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return interesse;
            }
        }
        public async Task<Interesse> Delete(Interesse interesse)
        {
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                _context.Interesse.Remove(interesse);
                await _context.SaveChangesAsync();
                return interesse;
            }
        }
    }
}