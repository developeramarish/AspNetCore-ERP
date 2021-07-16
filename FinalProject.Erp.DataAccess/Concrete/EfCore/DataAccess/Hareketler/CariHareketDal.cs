using FinalProject.Erp.Core.Concrete.EfCore.Repository;
using FinalProject.Erp.DataAccess.Abstract.Hareketler;
using FinalProject.Erp.Model.Entities.Hareketler;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Erp.DataAccess.Concrete.EfCore.DataAccess.Hareketler
{
    public class CariHareketDal : EfGenericRepository<CariHareket>, ICariHareketDal
    {
        public CariHareketDal(DbContext context) : base(context)
        {
        }
    }
}