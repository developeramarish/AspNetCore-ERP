using FinalProject.Erp.Model.Entities.Kartlar;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalProject.Erp.DataAccess.Concrete.EfCore.Mapping.Kartlar
{
    public class BankaMap : IEntityTypeConfiguration<Banka>
    {
        public void Configure(EntityTypeBuilder<Banka> builder)
        {
            builder.ToTable("Banka");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).UseIdentityColumn();
            builder.Property(a => a.Kod).IsRequired().HasMaxLength(20).HasColumnType("varchar");
            builder.HasIndex(a => a.Kod).IsUnique();
            builder.Property(a => a.BankaAdi).IsRequired().HasMaxLength(100).HasColumnType("varchar");
            builder.HasIndex(a => a.BankaAdi).IsUnique();
            builder.Property(a => a.BankaSube).HasMaxLength(100).HasColumnType("varchar");
            builder.Property(a => a.HesapNo).HasMaxLength(50).HasColumnType("varchar");
            builder.Property(a => a.IbanNo).HasMaxLength(40).HasColumnType("varchar");
            builder.Property(a => a.Yetkili).HasMaxLength(50).HasColumnType("varchar");
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