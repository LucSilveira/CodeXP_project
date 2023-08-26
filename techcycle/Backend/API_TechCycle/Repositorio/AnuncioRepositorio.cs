using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_TechCycle.Interfaces;
using API_TechCycle.Models;
using Microsoft.EntityFrameworkCore;

namespace API_TechCycle.Repositorio
{
    public class AnuncioRepositorio : IAnuncioRepositorio
    {
        public async Task<List<Anuncio>> Get()
        {
            List<Anuncio> listaDeAnuncios;
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                listaDeAnuncios = await _context.Anuncio.Include("IdAvaliacaoNavigation")
                    .Include("IdProdutoNavigation").Include("FotosAnuncio").ToListAsync();

                foreach(var anuncio in listaDeAnuncios)
                {
                    anuncio.IdAvaliacaoNavigation.Anuncio = null;
                    anuncio.IdProdutoNavigation.Anuncio = null;

                }
                return listaDeAnuncios;
            }
        }
        public async Task<Anuncio> Get(int id)
        {
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                return await _context.Anuncio.Include("IdAvaliacaoNavigation")
                    .Include("IdProdutoNavigation").Include("FotosAnuncio")
                        .FirstOrDefaultAsync(anc => anc.IdAnuncio == id);
            }
        }
        public async Task<Anuncio> Post(Anuncio anuncio)
        {
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                await _context.Anuncio.AddAsync(anuncio);
                await _context.SaveChangesAsync();
                return anuncio;
            }
        }
        public async Task<Anuncio> Put(Anuncio anuncio)
        {
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                _context.Entry(anuncio).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return anuncio;
            }
        }
        public async Task<Anuncio> Delete(Anuncio anuncio)
        {
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                _context.FotosAnuncio.RemoveRange(_context.FotosAnuncio.Where(fts => fts.IdAnuncio == anuncio.IdAnuncio));
                _context.Comentario.RemoveRange(_context.Comentario.Where(cmt => cmt.IdAnuncio == anuncio.IdAnuncio));
                _context.Interesse.RemoveRange(_context.Interesse.Where(itr => itr.IdAnuncio == anuncio.IdAnuncio));
                _context.Anuncio.Remove(anuncio);
                await _context.SaveChangesAsync();
                return anuncio;
            }
        }
    }
}