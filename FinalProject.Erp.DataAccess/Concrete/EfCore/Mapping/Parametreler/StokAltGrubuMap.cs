using FinalProject.Erp.Model.Entities.Parametreler;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalProject.Erp.DataAccess.Concrete.EfCore.Mapping.Parametreler
{
    public class StokAltGrubuMap : IEntityTypeConfiguration<StokAltGrubu>
    {
        public void Configure(EntityTypeBuilder<StokAltGrubu> builder)
        {
            builder.ToTable("StokAltGrubu");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).UseIdentityColumn();
            builder.Property(a => a.Kod).IsRequired().HasMaxLength(25).HasColumnType("varchar");
            builder.Property(a => a.StokAltGrubuAdi).IsRequired().HasMaxLength(50).HasColumnType("varchar");
            builder.Property(a => a.Aciklama).HasMaxLength(250).HasColumnType("varchar");
            builder.Property(a => a.Durum).IsRequired();
            builder.Property(a => a.Silindi).IsRequired();
        }
    }
}