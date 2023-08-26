using System.Collections.Generic;
using System.Threading.Tasks;
using API_TechCycle.Interfaces;
using API_TechCycle.Models;
using Microsoft.EntityFrameworkCore;

namespace API_TechCycle.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        public async Task<List<Produto>> Get()
        {
            List<Produto> listaProdutos;
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                listaProdutos =  await _context.Produto.Include("IdMarcaNavigation")
                    .Include("IdCategoriaNavigation").ToListAsync();

                foreach(var produto in listaProdutos)
                {
                    produto.IdMarcaNavigation.Produto = null;
                    produto.IdCategoriaNavigation.Produto = null;
                }
                return listaProdutos;
            }
        }
        public async Task<Produto> Get(int id)
        {
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                return await _context.Produto.Include("IdMarcaNavigation")
                    .Include("IdCategoriaNavigation").FirstOrDefaultAsync(pdt => pdt.IdProduto == id);
            }
        }
        public async Task<Produto> Post(Produto produto)
        {
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                await _context.Produto.AddAsync(produto);
                await _context.SaveChangesAsync();
                return produto;
            }
        }
        public async Task<Produto> Put(Produto produto)
        {
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                _context.Entry(produto).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return produto;
            }
        }
        public async Task<Produto> Delete(Produto produto)
        {
            using(TECHCYCLEContext _context = new TECHCYCLEContext())
            {
                _context.Produto.Remove(produto);
                await _context.SaveChangesAsync();
                return produto;
            }
        }
    }
}