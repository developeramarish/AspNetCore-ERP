using FinalProject.Erp.Model.Entities.Hareketler;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalProject.Erp.DataAccess.Concrete.EfCore.Mapping.Hareketler
{
    public class CariHareketMap : IEntityTypeConfiguration<CariHareket>
    {
        public void Configure(EntityTypeBuilder<CariHareket> builder)
        {
            builder.ToTable("CariHareket");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).UseIdentityColumn();
            builder.Property(a => a.Kod).IsRequired().HasMaxLength(20).HasColumnType("varchar");
            builder.HasIndex(a => a.Kod).IsUnique();
            builder.Property(a => a.GC).IsRequired().HasMaxLength(1).HasColumnType("varchar");
            builder.Property(a => a.MakbuzNo).HasMaxLength(20).HasColumnType("varchar");
            builder.Property(a => a.Tutar).IsRequired().HasPrecision(8, 2);
            builder.Property(a => a.Aciklama).HasMaxLength(250).HasColumnType("varchar");
            builder.Property(a => a.Silindi).IsRequired();
        }
    }
}