using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WM.Vitrine.API.Models;

namespace WM.Vitrine.API.Data.Mappings
{
    public class AnuncioMapping : IEntityTypeConfiguration<Anuncio>
    {
        public void Configure(EntityTypeBuilder<Anuncio> builder)
        {
            builder.HasKey(c => c.Id); 

            builder.Property(c => c.Make)
                .IsRequired()
                .HasColumnType("varchar(45)")
                .HasColumnName("Marca");

            builder.Property(c => c.Model)
                .IsRequired()
                .HasColumnType("varchar(45)")
                .HasColumnName("Modelo");

            builder.Property(c => c.Version)
                .IsRequired()
                .HasColumnType("varchar(45)")
                .HasColumnName("Versao");

            builder.Property(c => c.Year)
                .IsRequired()
                .HasColumnType("Int")
                .HasColumnName("Ano");

            builder.Property(c => c.Mileage)
                .IsRequired()
                .HasColumnType("Int")
                .HasColumnName("Quilometragem");

            builder.Property(c => c.Note)
                .IsRequired()
                .HasColumnType("text")
                .HasColumnName("Observacao");

            builder.ToTable("Tb_AnuncioWebmotors");
        }
    }
}
