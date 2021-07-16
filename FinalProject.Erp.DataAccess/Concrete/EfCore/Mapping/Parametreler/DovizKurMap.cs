using FinalProject.Erp.Model.Entities.Parametreler;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalProject.Erp.DataAccess.Concrete.EfCore.Mapping.Parametreler
{
    public class DovizKurMap : IEntityTypeConfiguration<DovizKur>
    {
        public void Configure(EntityTypeBuilder<DovizKur> builder)
        {
            builder.ToTable("DovizKur");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).UseIdentityColumn();
            builder.Property(a => a.Tarih).IsRequired().HasColumnType("datetime");
            builder.Property(a => a.DovizKodu).HasMaxLength(5).HasColumnType("varchar");
            builder.Property(a => a.DovizCinsi).HasMaxLength(100).HasColumnType("varchar");

            builder.Property(a => a.DovizAlis).HasPrecision(8, 4);
            builder.Property(a => a.DovizSatis).HasPrecision(8, 4);
            builder.Property(a => a.EfektifAlis).HasPrecision(8, 4);
            builder.Property(a => a.EfektifSatis).HasPrecision(8, 4);
        }
    }
}