using FinalProject.Erp.Core.Concrete.EfCore.Repository;
using FinalProject.Erp.DataAccess.Abstract.Parametreler;
using FinalProject.Erp.Model.Entities.Parametreler;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Erp.DataAccess.Concrete.EfCore.DataAccess.Parametreler
{
    public class EfBirimDal : EfGenericRepository<Birim>, IBirimDal
    {
        public EfBirimDal(DbContext context) : base(context)
        {
        }
    }
}