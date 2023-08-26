using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API_TechCycle.Models;
using API_TechCycle.Repositorio;
using API_TechCycle.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace API_TechCycle.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class InteresseController : ControllerBase
    {
        InteresseRepositorio repositorio = new InteresseRepositorio();
        EmailController _emailController = new EmailController();

        /// <summary>
        /// Tem a função de listar um interesse.
        /// </summary>
        /// <returns>Retorna uma lista de interesse.</returns>
        [HttpGet]
        public async Task<ActionResult<List<Interesse>>> Get()
        {
            try
            {
                var listaInteresses = await repositorio.Get();
                if(listaInteresses == null)
                {
                    return NotFound();
                }
                return listaInteresses;
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Tem a função de buscar um interesse na lista.
        /// </summary>
        /// <param name="id">Passa um id de um interesse</param>
        /// <returns>Retorna um interesse</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Interesse>> Get(int id)
        {
            try
            {
                Interesse interesse = await repositorio.Get(id);
                if(interesse == null)
                {
                    return NotFound();
                }
                return interesse;
            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpGet("aprovacao/{status}")]
        public async Task<ActionResult<List<Interesse>>> GetPorStatus(string status)
        {
            try
            {
                var listaDeInteresses = await repositorio.GetPorStatus(status);
                if(listaDeInteresses == null)
                {
                    return BadRequest();
                }
                return listaDeInteresses;
            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpGet("anuncio/{id}")]
        public async Task<ActionResult<List<Interesse>>> GetPorAnuncio(int id)
        {
            try
            {
                var listaDeInteresses = await repositorio.GetPorAnuncio(id);
                if(listaDeInteresses == null)
                {
                    return BadRequest();
                }
                return listaDeInteresses;
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Tem a função de cadastrar um novo interesse na lista.
        /// </summary>
        /// <param name="interesse">Passa um interesse.</param>
        /// <returns>Retorna um interesse.</returns>
        [HttpPost]
        public async Task<ActionResult<Interesse>> Post(CadInteresseViewModel interesse)
        {
            try
            {
                Interesse newInteresse = new Interesse();

                newInteresse.IdUsuarioInteressado = interesse.IdUsuarioInteressado;
                newInteresse.IdUsuarioAprovacao = 1;
                newInteresse.IdAnuncio = interesse.IdAnuncio;
                newInteresse.StatusAprovacao = "Aguardo";
                
                // string tituloEmail = "Interesse em um anuncio!";
                // string corpoEmail = System.IO.File.ReadAllText(path : @"emails\parabens.html");
                // _emailController.Email(newInteresse.IdUsuarioInteressadoNavigation.Email, corpoEmail, tituloEmail);

                await repositorio.Post(newInteresse);
                return newInteresse;
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Tem a função de buscar na lista um interesse.
        /// </summary>
        /// <param name="id">Passa um id de um interesse.</param>
        /// <param name="interesse">Passa um interesse para identificação.</param>
        /// <returns>Retorna um interesse.</returns>
        [HttpPut("{id}")]   
        public async Task<ActionResult<Interesse>> Put(int id, AltInteresseViewModel interesse)
        {
            try
            {
                var interesseExistente = await repositorio.Get(id);
                if(interesseExistente == null)
                {
                    return NotFound("Interesse não encontrado");
                }

                var interesseAlterado = verificacaoAlteracao(interesseExistente, interesse);
                var interesseComAlteracao = await repositorio.Put(interesseAlterado);
                return interesseComAlteracao;
            }
            catch(Exception)
            {
                var validarInteresse = await repositorio.Get(id);
                if(validarInteresse == null)
                {
                    return NotFound("Interesse não encontrado");
                }
                else
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Tem a função de exclúir um interesse na lista.
        /// </summary>
        /// <param name="id">Passa um id de um interesse.</param>
        /// <returns>Retorna um interesse.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Interesse>> Delete(int id)
        {
            try
            {
                var interesseExistente = await repositorio.Get(id);
                if(interesseExistente == null)
                {
                    return NotFound("Interesse não encontrado");
                }

                await repositorio.Delete(interesseExistente);
                return interesseExistente;
            }
            catch(Exception)
            {
                throw;
            }
        }

        private Interesse verificacaoAlteracao(Interesse interesse, AltInteresseViewModel alteracao)
        {
            if(alteracao.StatusAprovacao == null && alteracao == null)
            {
                interesse.StatusAprovacao = interesse.StatusAprovacao;
            }
            else if(alteracao.StatusAprovacao != null && interesse.StatusAprovacao != alteracao.StatusAprovacao)
            {
                interesse.StatusAprovacao = alteracao.StatusAprovacao;

                if(interesse.StatusAprovacao == "Aprovado")
                {
                    string tituloEmail = "Interesse em anúncio aprovado!";
                    string corpoEmail = System.IO.File.ReadAllText(path : @"emails\parabens.html");
                    _emailController.Email(interesse.IdUsuarioInteressadoNavigation.Email, corpoEmail, tituloEmail);
                }
            }


            if(alteracao.idAnuncio == 00 && alteracao == null)
            {
                interesse.IdAnuncio = interesse.IdAnuncio;
            }
            else if(alteracao.idAnuncio != 00 && interesse.IdAnuncio != alteracao.idAnuncio)
            {
                interesse.IdAnuncio = alteracao.idAnuncio;
            }


            if(alteracao.idUsuarioInteressado == 00 && alteracao == null)
            {
                interesse.IdUsuarioInteressado = interesse.IdUsuarioInteressado;
            }
            else if(alteracao.idUsuarioInteressado != 00 && interesse.IdUsuarioInteressado != alteracao.idUsuarioInteressado)
            {
                interesse.IdUsuarioInteressado = alteracao.idUsuarioInteressado;
            }


            if(alteracao.idUsuarioAprovacao == 00 && alteracao == null){
                interesse.IdUsuarioAprovacao = interesse.IdUsuarioAprovacao;
            }
            else if(alteracao.idUsuarioAprovacao != 00 && interesse.IdUsuarioAprovacao != alteracao.idUsuarioAprovacao)
            {
                interesse.IdUsuarioAprovacao = alteracao.idUsuarioAprovacao;
            }
            return interesse;
        }
    }
}