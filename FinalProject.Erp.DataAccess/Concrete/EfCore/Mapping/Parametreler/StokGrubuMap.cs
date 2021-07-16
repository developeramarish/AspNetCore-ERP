using FinalProject.Erp.Model.Entities.Parametreler;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalProject.Erp.DataAccess.Concrete.EfCore.Mapping.Parametreler
{
    public class StokGrubuMap : IEntityTypeConfiguration<StokGrubu>
    {
        public void Configure(EntityTypeBuilder<StokGrubu> builder)
        {
            builder.ToTable("StokGrubu");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).UseIdentityColumn();
            builder.Property(a => a.Kod).IsRequired().HasMaxLength(25).HasColumnType("varchar");
            builder.HasIndex(a => a.Kod).IsUnique();
            builder.Property(a => a.StokGrubuAdi).IsRequired().HasMaxLength(50).HasColumnType("varchar");
            builder.HasIndex(a => a.StokGrubuAdi).IsUnique();
            builder.Property(a => a.Aciklama).HasMaxLength(250).HasColumnType("varchar");
            builder.Property(a => a.Durum).IsRequired();
            builder.Property(a => a.Silindi).IsRequired();
        }
    }
}