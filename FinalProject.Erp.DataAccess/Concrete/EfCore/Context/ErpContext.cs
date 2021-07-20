using FinalProject.Erp.DataAccess.Concrete.EfCore.Mapping.Hareketler;
using FinalProject.Erp.DataAccess.Concrete.EfCore.Mapping.Kartlar;
using FinalProject.Erp.DataAccess.Concrete.EfCore.Mapping.Parametreler;
using FinalProject.Erp.Model.Entities.Hareketler;
using FinalProject.Erp.Model.Entities.Identity;
using FinalProject.Erp.Model.Entities.Kartlar;
using FinalProject.Erp.Model.Entities.Parametreler;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Erp.DataAccess.Concrete.EfCore.Context
{
    public class ErpContext : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                    @"Data Source=LAPTOP-F436T3TL\SQL2017; Initial Catalog=ciErpDb; User Id=sa; Password=1");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BirimMap());
            modelBuilder.ApplyConfiguration(new CariGrubuMap());
            modelBuilder.ApplyConfiguration(new CariAltGrubuMap());
            modelBuilder.ApplyConfiguration(new MarkaMap());
            modelBuilder.ApplyConfiguration(new ModelMap());
            modelBuilder.ApplyConfiguration(new OzelKodMap());
            modelBuilder.ApplyConfiguration(new SehirMap());
            modelBuilder.ApplyConfiguration(new IlceMap());
            modelBuilder.ApplyConfiguration(new StokGrubuMap());
            modelBuilder.ApplyConfiguration(new StokAltGrubuMap());
            modelBuilder.ApplyConfiguration(new StokTurMap());
            modelBuilder.ApplyConfiguration(new UlkeMap());
            modelBuilder.ApplyConfiguration(new DovizKurMap());
            //
            modelBuilder.ApplyConfiguration(new BankaMap());
            modelBuilder.ApplyConfiguration(new CariMap());
            modelBuilder.ApplyConfiguration(new DepoMap());
            modelBuilder.ApplyConfiguration(new KasaMap());
            modelBuilder.ApplyConfiguration(new StokMap());
            //
            modelBuilder.ApplyConfiguration(new BankaHareketMap());
            modelBuilder.ApplyConfiguration(new CariHareketMap());
            modelBuilder.ApplyConfiguration(new KasaHareketMap());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Birim> Birim { get; set; }
        public DbSet<CariGrubu> CariGrubu { get; set; }
        public DbSet<CariAltGrubu> CariAltGrubu { get; set; }
        public DbSet<Marka> Marka { get; set; }
        public DbSet<ModelKart> ModelKart { get; set; }
        public DbSet<OzelKod> OzelKod { get; set; }
        public DbSet<Sehir> Sehir { get; set; }
        public DbSet<Ilce> Ilce { get; set; }
        public DbSet<StokGrubu> StokGrubu { get; set; }
        public DbSet<StokAltGrubu> StokAltGrubu { get; set; }
        public DbSet<StokTur> StokTur { get; set; }
        public DbSet<Ulke> Ulke { get; set; }
        public DbSet<DovizKur> DovizKur { get; set; }
        //
        public DbSet<Banka> Banka { get; set; }
        public DbSet<Cari> Cari { get; set; }
        public DbSet<Depo> Depo { get; set; }
        public DbSet<Kasa> Kasa { get; set; }
        public DbSet<Stok> Stok { get; set; }
        //
        public DbSet<BankaHareket> BankaHareket { get; set; }
        public DbSet<CariHareket> CariHareket { get; set; }
        public DbSet<KasaHareket> KasaHareket { get; set; }
    }
}