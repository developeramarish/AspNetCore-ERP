using FinalProject.Erp.Model.Entities.Kartlar;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalProject.Erp.DataAccess.Concrete.EfCore.Mapping.Kartlar
{
    public class StokMap : IEntityTypeConfiguration<Stok>
    {
        public void Configure(EntityTypeBuilder<Stok> builder)
        {
            builder.ToTable("Stok");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).UseIdentityColumn();
            builder.Property(a => a.Kod).IsRequired().HasMaxLength(20).HasColumnType("varchar");
            builder.HasIndex(a => a.Kod).IsUnique();
            builder.Property(a => a.StokAdi).IsRequired().HasMaxLength(100).HasColumnType("varchar");
            builder.HasIndex(a => a.StokAdi).IsUnique();
            builder.Property(a => a.Barkod).HasMaxLength(50).HasColumnType("varchar");
            builder.Property(a => a.Aciklama).HasMaxLength(250).HasColumnType("varchar");
            builder.Property(a => a.AlisFiyat1).HasPrecision(8, 2);
            builder.Property(a => a.AlisFiyat2).HasPrecision(8, 2);
            builder.Property(a => a.AlisFiyat3).HasPrecision(8, 2);
            builder.Property(a => a.SatisFiyat1).HasPrecision(8, 2);
            builder.Property(a => a.SatisFiyat2).HasPrecision(8, 2);
            builder.Property(a => a.SatisFiyat3).HasPrecision(8, 2);
            builder.Property(a => a.Durum).IsRequired();
            builder.Property(a => a.Silindi).IsRequired();
        }
    }
}