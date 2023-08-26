using System.Collections.Generic;
using System.Threading.Tasks;
using API_TechCycle.Models;

namespace API_TechCycle.Interfaces
{
    public interface IFotosAnuncioRepositorio
    {
        Task<List<FotosAnuncio>> Get();
        Task<FotosAnuncio> Get(int id);
        Task<FotosAnuncio> Post(FotosAnuncio fotosAnuncio);
        Task<FotosAnuncio> Put(FotosAnuncio fotosAnuncio);
        Task<FotosAnuncio> Delete(FotosAnuncio fotosAnuncio);
    }
}