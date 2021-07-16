using FinalProject.Erp.Core.Concrete.EfCore.Repository;
using FinalProject.Erp.DataAccess.Abstract.Parametreler;
using FinalProject.Erp.Model.Entities.Parametreler;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Erp.DataAccess.Concrete.EfCore.DataAccess.Parametreler
{
    public class EfOzelKodDal : EfGenericRepository<OzelKod>, IOzelKodDal
    {
        public EfOzelKodDal(DbContext context) : base(context)
        {
        }
    }
}