using FinalProject.Erp.Model.Entities.Kartlar;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalProject.Erp.DataAccess.Concrete.EfCore.Mapping.Kartlar
{
    public class CariMap : IEntityTypeConfiguration<Cari>
    {
        public void Configure(EntityTypeBuilder<Cari> builder)
        {
            builder.ToTable("Cari");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).UseIdentityColumn();
            builder.Property(a => a.Kod).IsRequired().HasMaxLength(20).HasColumnType("varchar");
            builder.HasIndex(a => a.Kod).IsUnique();
            builder.Property(a => a.CariUnvani).IsRequired().HasMaxLength(100).HasColumnType("varchar");
            builder.HasIndex(a => a.CariUnvani).IsUnique();
            builder.Property(a => a.Yetkili).HasMaxLength(50).HasColumnType("varchar");
            builder.Property(a => a.VergiDaire).HasMaxLength(50).HasColumnType("varchar");
            builder.Property(a => a.VergiNo).HasMaxLength(25).HasColumnType("varchar");
            builder.Property(a => a.TcKimlikNo).HasMaxLength(15).HasColumnType("varchar");
            builder.Property(a => a.Adres).HasMaxLength(250).HasColumnType("varchar");
            builder.Property(a => a.Telefon).HasMaxLength(15).HasColumnType("varchar");
            builder.Property(a => a.Faks).HasMaxLength(15).HasColumnType("varchar");
            builder.Property(a => a.Gsm).HasMaxLength(15).HasColumnType("varchar");
            builder.Property(a => a.Email).HasMaxLength(100).HasColumnType("varchar");
            builder.Property(a => a.Web).HasMaxLength(100).HasColumnType("varchar");
            builder.Property(a => a.Aciklama).HasMaxLength(250).HasColumnType("varchar");
            builder.Property(a => a.Durum).IsRequired();
            builder.Property(a => a.Silindi).IsRequired();
        }
    }
}