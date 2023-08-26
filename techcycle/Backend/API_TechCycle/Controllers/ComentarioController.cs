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
    public class ComentarioController : ControllerBase
    {
        ComentarioRepositorio repositorio = new ComentarioRepositorio();

        /// <summary>
        /// Tem a função de listar um comentário.
        /// </summary>
        /// <returns>Retorna uma lista de comentário.</returns>
        [HttpGet]
        public async Task<ActionResult<List<Comentario>>> Get()
        {
            try
            {
                var listaComentarios = await repositorio.Get();
                if(listaComentarios == null)
                {
                    return NotFound("Nenhum comentario encontrado");
                }
                return listaComentarios;
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Tem a função de buscar um Comentário na lista.
        /// </summary>
        /// <param name="id">Passa um id de um Comentário</param>
        /// <returns>Retorna um Comentário</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Comentario>> Get(int id)
        {
            try
            {
                Comentario comentario = await repositorio.Get(id);
                if(comentario == null)
                {
                    return NotFound("Comentário não encontrado");
                }
                return comentario;
            }
            catch(Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Tem a função de cadastrar um novo comentário na lista.
        /// </summary>
        /// <param name="comentario">Passa um comentário.</param>
        /// <returns>Retorna um comentário.</returns>
        [HttpPost]
        public async Task<ActionResult<Comentario>> Post(CadComentarioViewModel comentario)
        {
            try
            {
                Comentario newComentario = new Comentario();
                newComentario.ComentarioTexto = comentario.ComentarioTexto;
                newComentario.IdAnuncio = comentario.idAnuncio;
                newComentario.IdUsuario = comentario.idUsuario;

                await repositorio.Post(newComentario);
                return newComentario;
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Tem a função de buscar na lista um comentário.
        /// </summary>
        /// <param name="id">Passa um id de um comentário.</param>
        /// <param name="comentario">Passa um comentário para identificação.</param>
        /// <returns>Retorna um comentário.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Comentario>> Put(int id, AltComentarioViewModel comentario)
        {
            try
            {
                var comentarioExistente = await repositorio.Get(id);
                if(comentarioExistente == null)
                {
                    return NotFound();
                }

                var comentarioAlterado = verificacaoAlteracao(comentarioExistente, comentario);
                var comentarioComAlteracao = await repositorio.Put(comentarioAlterado);
                return comentarioComAlteracao;
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Tem a função de exclúir um comentário na lista.
        /// </summary>
        /// <param name="id">Passa um id de um comentário.</param>
        /// <returns>Retorna um comentário.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Comentario>> Delete(int id)
        {
            try
            {
                Comentario comentario = await repositorio.Get(id);
                if(comentario == null)
                {
                    return NotFound("Comentário não encontrado");
                }
                await repositorio.Delete(comentario);
                return comentario;
            }
            catch(Exception)
            {
                throw;
            }
        }

        private Comentario verificacaoAlteracao(Comentario comentario, AltComentarioViewModel alteracao)
        {
            if(alteracao.ComentarioTexto == null && alteracao == null)
            {
                comentario.ComentarioTexto = comentario.ComentarioTexto;
            }
            else if(alteracao.ComentarioTexto != null && comentario.ComentarioTexto != alteracao.ComentarioTexto)
            {
                comentario.ComentarioTexto = alteracao.ComentarioTexto;
            }


            if(alteracao.idAnuncio == 00 && alteracao == null)
            {
                comentario.IdAnuncio = Convert.ToInt32(comentario.IdAnuncio);
            }
            else if(alteracao.idAnuncio != 00 && comentario.IdAnuncio != alteracao.idAnuncio)
            {
                comentario.IdAnuncio = Convert.ToInt32(alteracao.idAnuncio);
            }


            if(alteracao.idUsuario == 00 && alteracao == null)
            {
                comentario.IdUsuario = Convert.ToInt32(comentario.IdUsuario);
            }
            else if(alteracao.idUsuario != 00 && comentario.IdUsuario != alteracao.idUsuario)
            {
                comentario.IdUsuario = Convert.ToInt32(alteracao.idUsuario);
            }
            return comentario;
        }
    }
}