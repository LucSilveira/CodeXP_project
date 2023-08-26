using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API_TechCycle.Models;
using API_TechCycle.ViewModels;
using Microsoft.AspNetCore.Mvc;
using TechCycle_Back.Repositorio;

namespace API_TechCycle.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AvaliacaoController : ControllerBase
    {
        AvaliacaoRepositorio repositorio = new AvaliacaoRepositorio();

        /// <summary>
        /// Tem a função de listar uma avaliação.
        /// </summary>
        /// <returns>Retorna uma lista de avaliação.</returns>
        [HttpGet]
        public async Task<ActionResult<List<Avaliacao>>> Get()
        {
            try
            {
                var listaAvaliacao = await repositorio.Get();
                if(listaAvaliacao == null)
                {
                    return NotFound("Avaliações não encontrada");
                }
                return listaAvaliacao;
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Tem a função de buscar uma avaliação na lista.
        /// </summary>
        /// <param name="id">passa um id de uma avaliação.</param>
        /// <returns>Retorna uma avaliação.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Avaliacao>> Get(int id)
        {
            try
            {
                Avaliacao avaliacao = await repositorio.Get(id);
                if(avaliacao == null)
                {
                    return NotFound("Avaliação não encontrada");
                }
                return avaliacao;
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Tem a função de cadastra uma avaliação.
        /// </summary>
        /// <param name="avaliacao">Passa uma avaliação.</param>
        /// <returns>Retorna uma avaliação.</returns>
        [HttpPost]
        public async Task<ActionResult<Avaliacao>> Post(CadAvaliacaoViewModel avaliacao)
        {
            try
            {
                Avaliacao newAvaliacao = new Avaliacao();
                newAvaliacao.DescricaoAvaliacao = avaliacao.DescricaoAvaliacao;
                newAvaliacao.TipoAvaliacao = avaliacao.TipoAvaliacao;

                await repositorio.Post(newAvaliacao);
                return newAvaliacao;
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Tem a função de atualizar uma avaliação.
        /// </summary>
        /// <param name="id">Passa um id de uma avaliação.</param>
        /// <param name="avaliacao">Passa uma avaliação.</param>
        /// <returns>Retorna a avaliação atualizada.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Avaliacao>> Put(int id, AltAvaliacaoViewModel avaliacao)
        {
            try
            {
                var avaliacaoExiste = await repositorio.Get(id);
                if(avaliacaoExiste == null)
                {
                    return NoContent();
                }

                var avaliacaoAlterada = verificacaoAlteracao(avaliacaoExiste, avaliacao);
                var avaliacaoComAlteracao = await repositorio.Put(avaliacaoAlterada);
                return avaliacaoComAlteracao;
            }
            catch(Exception)
            {
                var validarAvaliacao = await repositorio.Get(id);
                if(validarAvaliacao == null)
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
        /// Tem a função de excluír uma avaliação.
        /// </summary>
        /// <param name="id">Passa um id de uma avaliação.</param>
        /// <returns>Retorna a avaliação excluída.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Avaliacao>> Delete(int id)
        {
            try
            {
                Avaliacao avaliacao = await repositorio.Get(id);
                if(avaliacao == null)
                {
                    return NotFound();
                }
                await repositorio.Delete(avaliacao);
                return avaliacao;
            }
            catch(Exception)
            {
                throw;
            }
        }

        private Avaliacao verificacaoAlteracao(Avaliacao avaliacao, AltAvaliacaoViewModel alteracao)
        {
            if(alteracao.DescricaoAvaliacao == null && alteracao == null)
            {
                avaliacao.DescricaoAvaliacao = avaliacao.DescricaoAvaliacao;
            }
            else if(alteracao.DescricaoAvaliacao != null && avaliacao.DescricaoAvaliacao != alteracao.DescricaoAvaliacao)
            {
                avaliacao.DescricaoAvaliacao = alteracao.DescricaoAvaliacao;
            }


            if(alteracao.TipoAvaliacao == null && alteracao == null)
            {
                avaliacao.TipoAvaliacao = avaliacao.TipoAvaliacao;
            }
            else if(alteracao.TipoAvaliacao != null && avaliacao.TipoAvaliacao != alteracao.TipoAvaliacao)
            {
                avaliacao.TipoAvaliacao = alteracao.TipoAvaliacao;
            }
            return avaliacao;
        }
    }
}