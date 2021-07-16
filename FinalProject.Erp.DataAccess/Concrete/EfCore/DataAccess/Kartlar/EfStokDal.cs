using FinalProject.Erp.Core.Concrete.EfCore.Repository;
using FinalProject.Erp.DataAccess.Abstract.Kartlar;
using FinalProject.Erp.Model.Entities.Kartlar;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Erp.DataAccess.Concrete.EfCore.DataAccess.Kartlar
{
    public class EfStokDal : EfGenericRepository<Stok>, IStokDal
    {
        public EfStokDal(DbContext context) : base(context)
        {
        }
    }
}