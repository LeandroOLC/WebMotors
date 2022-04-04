using Microsoft.EntityFrameworkCore;
using WM.WebApp.MVC.Models;

namespace WM.WebApp.MVC
{
    public class MeuContext : DbContext
    {
        public MeuContext(DbContextOptions<MeuContext> options) : base(options) { }

        public DbSet<AnunciosViewModel> Cars { get; set; }
        //public DbSet<MakeViewModel> Make { get; set; }
        //public DbSet<ModelViewModel> Model { get; set; }
        //public DbSet<VersionsViewModel> Versions { get; set; }
        //public DbSet<VehicleViewModel> Vehicle { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuContext).Assembly);
        }
        //public DbSet<MakeViewModel> Make { get; set; }
        //public DbSet<ModelViewModel> Model { get; set; }
        //public DbSet<VersionsViewModel> Versions { get; set; }
        //public DbSet<VehicleViewModel> Vehicle { get; set; }

        public DbSet<WM.WebApp.MVC.Models.VehicleViewModel> VehicleViewModel { get; set; }
    }
}
