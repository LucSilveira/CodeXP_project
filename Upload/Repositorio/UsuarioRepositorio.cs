using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Upload.Interface;
using Upload.Models;

namespace Upload.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        UploadContext context = new UploadContext();


        public async Task<List<Usuario>> Get()
        {
            return await context.Usuario.ToListAsync();
        }

        public async Task<Usuario> Get(int id)
        {
             return await context.Usuario.FindAsync(id);
        }

        public async Task<Usuario> Post(Usuario usuario)
        {            

            await context.Usuario.AddAsync(usuario);
            await context.SaveChangesAsync();

            return usuario;
        }

        public async Task<Usuario> Put(Usuario usuario)
        {
            context.Entry(usuario).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return usuario;
        }
        public async Task<Usuario> Delete(Usuario usuario)
        {
            context.Usuario.Remove(usuario);
            await context.SaveChangesAsync();

            return usuario;
        }
    }
}