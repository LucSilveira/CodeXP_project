using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_TechCycle.Controllers;
using API_TechCycle.Interfaces;
using API_TechCycle.Models;
using Microsoft.EntityFrameworkCore;

namespace API_TechCycle.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        UploadController upload = new UploadController();
        EmailController _emailController = new EmailController();

        public async Task<List<Usuario>> Get()
        {
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                return await _context.Usuario.ToListAsync();
            }
        }
        public async Task<Usuario> Get(int id)
        {
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                return await _context.Usuario.FirstOrDefaultAsync(usr => usr.IdUsuario == id);
            }
        }
        public async Task<List<Usuario>> GetPorStatus(string statusAprovacao)
        {
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                List<Usuario> listaUsuarioStatus =
                    await _context.Usuario.Where(usr => usr.StatusAprovacao == statusAprovacao).ToListAsync();

                return listaUsuarioStatus;
            }
        }
        public async Task<Usuario> Post(Usuario usuario)
        {
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                await _context.Usuario.AddAsync(usuario);
                await _context.SaveChangesAsync();

                return usuario;
            }
        }
        public async Task<Usuario> Put(Usuario usuario)
        {
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                _context.Entry(usuario).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return usuario;
            }
        }
        public async Task<Usuario> Delete(Usuario usuario)
        {
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                _context.Interesse.RemoveRange(_context.Interesse.Where(itr => itr.IdUsuarioInteressado == usuario.IdUsuario));
                _context.Comentario.RemoveRange(_context.Comentario.Where(cmt => cmt.IdUsuario == usuario.IdUsuario));
                _context.Usuario.Remove(usuario);
                await _context.SaveChangesAsync();

                return usuario;
            }
        }
        public async Task<Usuario> verificacaoDeUso(string email, string loginUsuario)
        {
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                Usuario usuarioComVerificacao = await _context.Usuario
                    .Where(user => user.Email == email || user.LoginUsuario == loginUsuario).FirstOrDefaultAsync();
                return usuarioComVerificacao;
            }
        }
        public async Task<Usuario> verificacaoDeStatus(string status)
        {
            using (TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                Usuario usuarioComVerificacao = await _context.Usuario
                    .FirstOrDefaultAsync(user => user.StatusAprovacao == status);

                return usuarioComVerificacao;
            }
        }
        public async Task<Usuario> GetEmailUsuario(string email)
        {
            using (TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                Usuario usuarioComEmail = await _context.Usuario
                    .FirstOrDefaultAsync(user => user.Email == email);

                // _context.Entry(usuarioComEmail).State = EntityState.Modified;
                // await _context.SaveChangesAsync();

                return usuarioComEmail;
            }
        }
    }
}