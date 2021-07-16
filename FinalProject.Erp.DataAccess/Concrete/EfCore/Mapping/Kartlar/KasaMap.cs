using FinalProject.Erp.Model.Entities.Kartlar;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalProject.Erp.DataAccess.Concrete.EfCore.Mapping.Kartlar
{
    public class KasaMap : IEntityTypeConfiguration<Kasa>
    {
        public void Configure(EntityTypeBuilder<Kasa> builder)
        {
            builder.ToTable("Kasa");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).UseIdentityColumn();
            builder.Property(a => a.Kod).IsRequired().HasMaxLength(20).HasColumnType("varchar");
            builder.HasIndex(a => a.Kod).IsUnique();
            builder.Property(a => a.KasaAdi).IsRequired().HasMaxLength(50).HasColumnType("varchar");
            builder.HasIndex(a => a.KasaAdi).IsUnique();
            builder.Property(a => a.Yetkili).HasMaxLength(50).HasColumnType("varchar");
            builder.Property(a => a.Aciklama).HasMaxLength(250).HasColumnType("varchar");
            builder.Property(a => a.Durum).IsRequired();
            builder.Property(a => a.Silindi).IsRequired();
        }
    }
}