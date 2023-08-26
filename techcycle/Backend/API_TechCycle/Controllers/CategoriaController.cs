using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API_TechCycle.Models;
using API_TechCycle.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechCycle_Back.Repositorio;

namespace API_TechCycle.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CategoriaController : ControllerBase
    {
        CategoriaRepositorio repositorio = new CategoriaRepositorio();

        /// <summary>
        /// Tem a função de listar uma categoria.
        /// </summary>
        /// <returns>Retorna uma lista de categoria.</returns>
        
        // [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> Get()
        {
            try
            {
                return await repositorio.Get();
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Tem a função de buscar uma categoria na lista.
        /// </summary>
        /// <param name="id">passa um id de uma categoria.</param>
        /// <returns>Retorna uma categoria.</returns>

        // [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> Get(int id)
        {
            try
            {
                Categoria categoria = await repositorio.Get(id);
                if(categoria == null)
                    return NotFound();    

                return categoria;        
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Tem a função de cadastra uma categoria.
        /// </summary>
        /// <param name="categoria">Passa uma categoria.</param>
        /// <returns>Retorna uma categoria.</returns>
        
        // [Authorize(Roles = "Administrador")]
        [HttpPost]
        public async Task<ActionResult<Categoria>> Post(Categoria categoria)
        {
            try
            {
                await repositorio.Post(categoria);
                return categoria;
            }
            catch(Exception)
            {
                throw;
            }
        }
    
        /// <summary>
        /// Tem a função de atualizar uma categoria
        /// </summary>
        /// <param name="id">Passa o id de uma categoria</param>
        /// <param name="categoria">Passa uma categoria</param>
        /// <returns>Retorna a categoria atualizada</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Categoria>> Put(int id, AltCategoriaViewModel categoria)
        {            
            try
            {
                var categoriaExistente = await repositorio.Get(id);
                if(categoriaExistente == null)
                {
                    return NotFound("Categoria não foi encontrada!");
                }

                var categoriaAlterada = verificacaoAlteracao(categoriaExistente, categoria);
                var categoriaComAlteracao = await repositorio.Put(categoriaAlterada);

                return categoriaComAlteracao;
            }
            catch(DbUpdateConcurrencyException)
            {
                var validarCategoria = repositorio.Get(id);
                if(validarCategoria == null)
                {
                    return NotFound("Categoria não existe");
                }
                else
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Tem a função de excluír uma categoria.
        /// </summary>
        /// <param name="id">Passa um id de uma categoria.</param>
        /// <returns>Retorna a categoria excluída.</returns>
    
        // [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Categoria>> Delete(int id)
        {
            try
            {
                Categoria categoria = await repositorio.Get(id);

                if(categoria == null)
                {
                    return NotFound("Categoria não existe!");
                }

                await repositorio.Delete(categoria);
                return categoria;
            }
            catch(Exception)
            {
                throw;
            }
        }
        
        private Categoria verificacaoAlteracao(Categoria categoria, AltCategoriaViewModel alteracao)
        {

            if(alteracao.nomeCategoria == null && alteracao == null)
            {
                categoria.NomeCategoria = categoria.NomeCategoria;
            }
            else if(alteracao.nomeCategoria != null && categoria.NomeCategoria != alteracao.nomeCategoria)
            {
                categoria.NomeCategoria = alteracao.nomeCategoria;
            }

            return categoria;
        }
    }
}