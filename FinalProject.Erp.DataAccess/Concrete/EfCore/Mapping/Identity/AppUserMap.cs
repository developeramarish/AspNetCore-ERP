using FinalProject.Erp.Model.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalProject.Erp.DataAccess.Concrete.EfCore.Mapping.Identity
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            //builder.ToTable("Personel");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).UseIdentityColumn();
            builder.Property(a => a.Adi).IsRequired().HasMaxLength(25).HasColumnType("varchar");
            builder.Property(a => a.Soyadi).IsRequired().HasMaxLength(25).HasColumnType("varchar");
            builder.Property(a => a.Gsm).HasMaxLength(15).HasColumnType("varchar");
        }
    }
}