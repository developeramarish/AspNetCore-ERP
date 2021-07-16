using FinalProject.Erp.Business.Abstract.Base;
using FinalProject.Erp.Model.Dtos.Kartlar;
using FinalProject.Erp.Model.Entities.Kartlar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FinalProject.Erp.Business.Abstract.Kartlar
{
    public interface IBankaService : IBaseService<Banka>
    {
        BankaEditDto GetDto(Expression<Func<Banka, bool>> filter);
        IEnumerable<BankaListDto> GetAllDto(Expression<Func<Banka, bool>> filter = null, Func<IQueryable<Banka>, IOrderedQueryable<Banka>> orderBy = null);
    }
}