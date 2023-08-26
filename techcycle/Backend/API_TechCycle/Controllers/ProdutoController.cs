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
    public class ProdutoController : ControllerBase
    {
        ProdutoRepositorio repositorio = new ProdutoRepositorio();

        /// <summary>
        /// Tem a função de trazer uma lista de produto.
        /// </summary>
        /// <returns>Retorna uma lista de produto</returns>
        [HttpGet]
        public async Task<ActionResult<List<Produto>>> Get()
        {
            try{
                var listaProdutos = await repositorio.Get();
                if(listaProdutos == null)
                {
                    return NotFound();
                }
                return listaProdutos;
            }
            catch(Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Tem a função de buscar um produto na lista.
        /// </summary>
        /// <param name="id">Passa um id de um produto</param>
        /// <returns>Retorna um Produto</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> Get(int id)
        {
            try
            {
                Produto produto = await repositorio.Get(id);
                if(produto == null)
                {
                    return NotFound();
                }
                return produto;
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Tem a função de cadastrar um novo produto na lista.
        /// </summary>
        /// <param name="produto">Passa um produto.</param>
        /// <returns>Retorna um produto.</returns>
        [HttpPost]
        public async Task<ActionResult<Produto>> Post(CadProdutoViewModel produto)
        {
            try
            {
                Produto newProduto = new Produto();

                newProduto.NomeProduto = produto.NomeProduto;
                newProduto.ModeloProduto = produto.ModeloProduto;
                newProduto.CodIdentificacao = produto.CodIdentificacao;
                newProduto.MemoriaProduto = produto.MemoriaProduto;
                newProduto.Processador = produto.Processador;
                newProduto.Descricao = produto.Descricao;
                newProduto.DataLancamento = produto.DataLancamento;
                newProduto.IdCategoria = produto.IdCategoria;
                newProduto.IdMarca = produto.IdMarca;

                await repositorio.Post(newProduto);
                return newProduto;
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Tem a função de buscar na lista um produto.
        /// </summary>
        /// <param name="id">Passa um id de um produto.</param>
        /// <param name="produto">Passa um Produto para identificação.</param>
        /// <returns>Retorna um produto.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Produto>> Put(int id, AltProdutoViewModel produto)
        {
            try
            {
                var produtoExiste = await repositorio.Get(id);
                if(produtoExiste == null)
                {
                    return NotFound();
                }

                var produtoAlterado = verificacaoAlteracao(produtoExiste, produto);
                var produtoComAlteracao = await repositorio.Put(produtoAlterado);
                return produtoComAlteracao;
            }
            catch(Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Tem a função excluír um produto da lista.
        /// </summary>
        /// <param name="id">Passa um id do produto.</param>
        /// <returns>Retorna um produto</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Produto>> Delete(int id)
        {
            try
            {
                Produto produto = await repositorio.Get(id);
                if(produto == null)
                {
                    return NotFound();
                }
                await repositorio.Delete(produto);
                return produto;
            }
            catch(Exception)
            {
                throw;
            }
        }
        
        private Produto verificacaoAlteracao(Produto produto, AltProdutoViewModel alteracao)
        {
            if(alteracao.NomeProduto == null && alteracao == null)
            {
                produto.NomeProduto = produto.NomeProduto;
            }
            else if(alteracao.NomeProduto != null && produto.NomeProduto != alteracao.NomeProduto)
            {
                produto.NomeProduto = alteracao.NomeProduto;
            }
            

            if(alteracao.ModeloProduto == null && alteracao == null)
            {
                produto.ModeloProduto = produto.ModeloProduto;
            }
            else if(alteracao.ModeloProduto != null && produto.ModeloProduto != alteracao.ModeloProduto)
            {
                produto.ModeloProduto = alteracao.ModeloProduto;
            }


            if(alteracao.MemoriaProduto == 00 && alteracao == null)
            {
                produto.MemoriaProduto = produto.MemoriaProduto;
            }
            else if(alteracao.MemoriaProduto != 00 && produto.MemoriaProduto != alteracao.MemoriaProduto)
            {
                produto.MemoriaProduto = alteracao.MemoriaProduto;
            }


            if(alteracao.Descricao == null && alteracao == null)
            {
                produto.Descricao = produto.Descricao;
            }
            else if(alteracao.Descricao != null && produto.Descricao != alteracao.Descricao)
            {
                produto.Descricao = alteracao.Descricao;
            }


            if(alteracao.CodIdentificacao == null && alteracao == null)
            {
                produto.CodIdentificacao = produto.CodIdentificacao;
            }
            else if(alteracao.CodIdentificacao != null && produto.CodIdentificacao != alteracao.CodIdentificacao)
            {
                produto.CodIdentificacao = alteracao.CodIdentificacao;
            }


            if(alteracao.Processador == null && alteracao == null)
            {
                produto.NomeProduto = produto.NomeProduto;
            }
            else if(alteracao.Processador != null && produto.Processador != alteracao.Processador)
            {
                produto.Processador = alteracao.Processador;
            }


            if(alteracao.DataLancamento == null && alteracao == null)
            {
                produto.DataLancamento = produto.DataLancamento;
            }
            else if(produto.DataLancamento != produto.DataLancamento)
            {
                produto.DataLancamento = alteracao.DataLancamento;
            }


            if(alteracao.IdMarca == 00 && alteracao == null)
            {
                produto.IdMarca = Convert.ToInt32(produto.IdMarca);
            }
            else if(alteracao.IdMarca != 00 && produto.IdMarca != alteracao.IdMarca)
            {
                produto.IdMarca = Convert.ToInt32(alteracao.IdMarca);
            }


            if(alteracao.IdCategoria == 00 && alteracao == null)
            {
                produto.IdCategoria = Convert.ToInt32(produto.IdCategoria);
            }
            else if(alteracao.IdCategoria != 00 && produto.IdCategoria != alteracao.IdCategoria)
            {
                produto.IdCategoria = Convert.ToInt32(alteracao.IdCategoria);
            }

            return produto;
        }
    }
}