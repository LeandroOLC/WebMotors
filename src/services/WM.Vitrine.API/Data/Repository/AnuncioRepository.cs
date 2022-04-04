using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WM.Vitrine.API.Models;
using WM.WebAPI.Core.Data;

namespace WM.Vitrine.API.Data.Repository
{
    public class AnuncioRepository : IAnuncioRepository
    {
        private readonly VitrineContext _context;

        public AnuncioRepository(VitrineContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<List<Anuncio>> GetAsync()
        {
            return await _context.Anuncio.AsNoTracking().ToListAsync();
        }

        public void DeleteAsync(Anuncio entity)
        {
            _context.Anuncio.Remove(entity);
        }

        public void AddAsync(Anuncio entity)
        {
            _context.Anuncio.Add(entity);
        }

        public async Task<Anuncio> GetByIdAsync(int id)
        {
            return await _context.Anuncio.AsNoTracking().FirstOrDefaultAsync(c => c.Id.Equals(id));
        }

        public void UpdateAsync(Anuncio entity)
        {
            _context.Anuncio.Update(entity);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
