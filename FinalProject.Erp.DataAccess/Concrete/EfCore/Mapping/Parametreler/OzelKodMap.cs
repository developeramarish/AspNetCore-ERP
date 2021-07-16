using FinalProject.Erp.Model.Entities.Parametreler;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalProject.Erp.DataAccess.Concrete.EfCore.Mapping.Parametreler
{
    public class OzelKodMap : IEntityTypeConfiguration<OzelKod>
    {
        public void Configure(EntityTypeBuilder<OzelKod> builder)
        {
            builder.ToTable("OzelKod");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).UseIdentityColumn();
            builder.Property(a => a.Kod).IsRequired().HasMaxLength(25).HasColumnType("varchar");
            builder.HasIndex(a => a.Kod);
            builder.Property(a => a.OzelKodAdi).IsRequired().HasMaxLength(50).HasColumnType("varchar");
            builder.HasIndex(a => a.OzelKodAdi);
            builder.Property(a => a.Aciklama).HasMaxLength(250).HasColumnType("varchar");
            builder.Property(a => a.Durum).IsRequired();
            builder.Property(a => a.Silindi).IsRequired();
        }
    }
}