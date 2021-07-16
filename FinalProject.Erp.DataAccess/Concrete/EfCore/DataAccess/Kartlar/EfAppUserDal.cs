using FinalProject.Erp.Core.Concrete.EfCore.Repository;
using FinalProject.Erp.DataAccess.Abstract.Kartlar;
using FinalProject.Erp.Model.Entities.Identity;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Erp.DataAccess.Concrete.EfCore.DataAccess.Kartlar
{
    public class EfAppUserDal : EfGenericRepository<AppUser>, IAppUserDal
    {
        public EfAppUserDal(DbContext context) : base(context)
        {
        }
    }
}