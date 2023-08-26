using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API_TechCycle.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechCycle_Back.Repositorio;
using TechCycle_Back.ViewModels;

namespace TechCycle_Back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class MarcaController : ControllerBase
    {
        MarcaRepositorio repositorio = new MarcaRepositorio();

        /// <summary>
        /// Tem a função de listar uma marca.
        /// </summary>
        /// <returns>Retorna uma lista de marca.</returns>
        
        // [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<Marca>>> Get()
        {
            try
            {
                var listaDeMarcas = await repositorio.Get();
                if(listaDeMarcas == null)
                {
                    return NotFound("Nenhuma marca encontrada");
                }
                return listaDeMarcas;
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Tem a função de buscar uma marca na lista.
        /// </summary>
        /// <param name="id">passa um id de uma marca.</param>
        /// <returns>Retorna uma marca.</returns>
        
        // [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Marca>> Get(int id)
        {
            try
            {
                Marca marca = await repositorio.Get(id);
                if(marca == null)
                {
                    return NotFound("Marca não encontrada");
                }
                return marca;
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Tem a função de cadastra uma marca.
        /// </summary>
        /// <param name="marca">Passa uma marca.</param>
        /// <returns>Retorna uma marca.</returns>
        // [Authorize(Roles = "Administrador")]
        [HttpPost]
        public async Task<ActionResult<Marca>> Post(Marca marca)
        {
            try
            {
                await repositorio.Post(marca);
            }
            catch(Exception)
            {
                throw;
            }
            return marca;
        }

        /// <summary>
        /// Tem a função de atualizar uma marca.
        /// </summary>
        /// <param name="id">Passa um id de uma marca.</param>
        /// <param name="marca">Passa uma marca.</param>
        /// <returns>Retorna a marca atualizada.</returns>
        
        // [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public async Task<ActionResult<Marca>> Put(int id, [FromBody]AltMarcaViewModel marca)
        {
            try
            {
                var marcaExistente = await repositorio.Get(id);
                if(marcaExistente == null)
                {
                    return NotFound("A marca informada não existe!");
                }

                var marcaAlterada = verificacaoAteracao(marcaExistente, marca);
                var marcaComAlteracao = await repositorio.Put(marcaAlterada);

                return marcaComAlteracao;
            }
            catch(DbUpdateConcurrencyException)
            {
                var validarMarca = await repositorio.Get(id);

                if(validarMarca == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Tem a função de excluír uma marca.
        /// </summary>
        /// <param name="id">Passa um id de uma marca.</param>
        /// <returns>Retorna a marca excluída.</returns>
        
        // [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Marca>> Delete(int id)
        {
            try
            {
                Marca marca = await repositorio.Get(id);
                if(marca == null)
                {
                    return NotFound("Marca não informada");
                }
                await repositorio.Delete(marca);
                return marca;
            }
            catch(Exception)
            {
                throw;
            }
        }

        private Marca verificacaoAteracao(Marca marca, AltMarcaViewModel alteracao)
        {
            if(alteracao.NomeMarca == null && alteracao == null)
            {
                marca.NomeMarca = marca.NomeMarca;
            }
            else if(alteracao.NomeMarca != null && marca.NomeMarca != alteracao.NomeMarca)
            {
                marca.NomeMarca = alteracao.NomeMarca;
            }
            return marca;
        }
    }
}