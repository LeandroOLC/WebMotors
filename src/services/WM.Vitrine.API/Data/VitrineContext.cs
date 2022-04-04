using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WM.Vitrine.API.Models;
using WM.WebAPI.Core.Data;

namespace WM.Vitrine.API.Data
{
    public class VitrineContext : DbContext, IUnitOfWork
    {
        public VitrineContext(DbContextOptions<VitrineContext> options) : base(options) { }

        public DbSet<Anuncio> Anuncio { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<int>("Id").StartsAt(1000).IncrementsBy(1);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VitrineContext).Assembly);
        }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}
