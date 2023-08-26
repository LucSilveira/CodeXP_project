using System.Collections.Generic;
using System.Threading.Tasks;
using API_TechCycle.Interfaces;
using API_TechCycle.Models;
using Microsoft.EntityFrameworkCore;

namespace API_TechCycle.Repositorio
{
    public class ComentarioRepositorio : IComentarioRepositorio
    {
        public async Task<List<Comentario>> Get()
        {
            List<Comentario> listaDeComentarios;
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                listaDeComentarios = await _context.Comentario.Include("IdAnuncioNavigation").Include("IdUsuarioNavigation")
                    .ToListAsync();

                foreach(var comentario in listaDeComentarios)
                {
                    comentario.IdAnuncioNavigation.Comentario = null;
                    comentario.IdUsuarioNavigation.Comentario = null;
                }
                return listaDeComentarios;
            }
        }
        public async Task<Comentario> Get(int id)
        {
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                return await _context.Comentario.Include("IdAnuncioNavigation").Include("IdUsuarioNavigation")
                    .FirstOrDefaultAsync(cmt => cmt.IdComentario == id);
            }
        }
        public async Task<Comentario> Post(Comentario comentario)
        {
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                await _context.Comentario.AddAsync(comentario);
                await _context.SaveChangesAsync();
                return comentario;
            }
        }
        public async Task<Comentario> Put(Comentario comentario)
        {
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                _context.Entry(comentario).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return comentario;   
            }
        }
        public async Task<Comentario> Delete(Comentario comentario)
        {
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                _context.Comentario.Remove(comentario);
                await _context.SaveChangesAsync();
                return comentario;
            }
        }
    }
}