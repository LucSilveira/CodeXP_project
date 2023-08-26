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
    public class AnuncioController : ControllerBase
    {
        AnuncioRepositorio repositorio = new AnuncioRepositorio();
        UploadController _uploadController = new UploadController();

        /// <summary>
        /// Tem a função de listar um anúncio.
        /// </summary>
        /// <returns>Retorna uma lista de anúncio.</returns>
        [HttpGet]
        public async Task<ActionResult<List<Anuncio>>> Get()
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
        /// Tem a função de buscar um anúncio na lista.
        /// </summary>
        /// <param name="id">Passa um id de um anúncio</param>
        /// <returns>Retorna um anúncio</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Anuncio>> Get(int id)
        {
            try
            {
                var anuncioExistente = await repositorio.Get(id);
                if(anuncioExistente == null)
                {
                    return NotFound("Anuncio não encontrado");
                }
                return anuncioExistente;
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Tem a função de cadastrar um novo anúncio na lista.
        /// </summary>
        /// <param name="anuncio">Passa um anúncio.</param>
        /// <returns>Retorna um anúncio.</returns>
        [HttpPost]
        public async Task<ActionResult<Anuncio>> Post([FromForm]CadAnuncioViewModel anuncio)
        {
            try
            {
                Anuncio newAnuncio = new Anuncio();

                var files = Request.Form.Files;
                if(files.Count > 0 && files.Count == 3)
                {
                    var listaFotosAnuncio = new List<FotosAnuncio>();

                    foreach(var file in files)
                    {
                        var arquivo = Request.Form.Files[0];
                        var caminhoPasta = @"Resources\Anuncio\";

                        var fotosAnuncio = _uploadController.Upload(arquivo, caminhoPasta);
                        listaFotosAnuncio.Add(new FotosAnuncio(){
                            FotoDoAnuncio = fotosAnuncio
                        });
                    }
                    
                    newAnuncio.PrecoAnuncio = anuncio.precoAnuncio;
                    newAnuncio.DataExpiracao = anuncio.dataLancamento;
                    newAnuncio.IdAvaliacao = anuncio.idAvaliacao;
                    newAnuncio.IdProduto = anuncio.idProduto;
                    newAnuncio.FotosAnuncio = listaFotosAnuncio;
                }
                else
                {
                    if(Request.Form.Files.Count == 0)
                    {
                        return BadRequest("Nenhuma Foto enviada!");
                    }
                }
                await repositorio.Post(newAnuncio);
                return newAnuncio;
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Tem a função de buscar na lista um anúncio.
        /// </summary>
        /// <param name="id">Passa um id de um anúncio.</param>
        /// <param name="anuncio">Passa um anúncio para identificação.</param>
        /// <returns>Retorna um anúncio.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Anuncio>> Put(int id, [FromForm]AltAnuncioViewModel anuncio)
        {
            try
            {
                var anuncioExistente = await repositorio.Get(id);
                if(anuncioExistente == null)
                {
                    return NotFound("Anúncio não encontrado");
                }

                var anuncioAlterado = verificacaoAlteracao(anuncioExistente, anuncio);
                var anuncioComAlteracao = await repositorio.Put(anuncioAlterado);
                return anuncioComAlteracao;
            }
            catch(Exception)
            {
                var anuncioValidacao = await repositorio.Get(id);
                if(anuncioValidacao == null)
                {
                    return NotFound("Anuncio não encontrado");
                }
                else
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Tem a função de exclúir um anúncio na lista.
        /// </summary>
        /// <param name="id">Passa um id de um anúncio.</param>
        /// <returns>Retorna um anúncio.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Anuncio>> Delete(int id)
        {
            try
            {
                var anuncioExistente = await repositorio.Get(id);
                if(anuncioExistente == null)
                {
                    return NotFound("Anúncio não encontrado");
                }
                await repositorio.Delete(anuncioExistente);
                return anuncioExistente;
            }
            catch(Exception)
            {
                throw;
            }
        }

        private Anuncio verificacaoAlteracao(Anuncio anuncio, AltAnuncioViewModel alteracao)
        {
            if(alteracao.precoAnuncio == 00 && alteracao == null)
            {
                anuncio.PrecoAnuncio = anuncio.PrecoAnuncio;
            }
            else if(alteracao.precoAnuncio != 00 && anuncio.PrecoAnuncio != alteracao.precoAnuncio)
            {
                anuncio.PrecoAnuncio = alteracao.precoAnuncio;
            }


            if(alteracao.dataLancamento == null && alteracao == null)
            {
                anuncio.DataExpiracao = anuncio.DataExpiracao;
            }
            else if(alteracao.dataLancamento != null && anuncio.DataExpiracao != alteracao.dataLancamento)
            {
                anuncio.DataExpiracao = alteracao.dataLancamento;
            }


            if(alteracao.idAvaliacao == 00 & alteracao == null)
            {
                anuncio.IdAnuncio = Convert.ToInt32(anuncio.IdAnuncio);
            }
            else if(alteracao.idAvaliacao != 00 && anuncio.IdAnuncio != alteracao.idAvaliacao)
            {
                anuncio.IdAnuncio = Convert.ToInt32(alteracao.idAvaliacao);
            }


            if(alteracao.idProduto == 00 & alteracao == null)
            {
                anuncio.IdProduto = Convert.ToInt32(anuncio.IdProduto);
            }
            else if(alteracao.idProduto != 00 && anuncio.IdProduto != alteracao.idProduto)
            {
                anuncio.IdProduto = Convert.ToInt32(alteracao.idProduto);
            }


            var files = Request.Form.Files;
            if(files.Count > 0 && files.Count <= 3)
            {
                var listaDeFotos = new List<FotosAnuncio>();

                foreach( var file in files)
                {
                    var arquivo = Request.Form.Files[0];
                    var caminhoPasta = @"Resources\Anuncio\";

                    var fotosAnuncio = _uploadController.Upload(arquivo, caminhoPasta);
                        listaDeFotos.Add(new FotosAnuncio(){
                            FotoDoAnuncio = fotosAnuncio
                    });
                }
                anuncio.FotosAnuncio = listaDeFotos;
            }
            return anuncio;
        }
    }
}