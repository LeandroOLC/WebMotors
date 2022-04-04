using System.Collections.Generic;
using System.Threading.Tasks;
using WM.Vitrine.API.Models;

namespace WM.Vitrine.API.Data.Repository
{
    public interface IAnuncioRepository : IRepository<Anuncio>
    {
        Task<List<Anuncio>> GetAsync();

        void DeleteAsync(Anuncio entity);

        void AddAsync(Anuncio entity);

        Task<Anuncio> GetByIdAsync(int id);

        void UpdateAsync(Anuncio entity);
    }
}
