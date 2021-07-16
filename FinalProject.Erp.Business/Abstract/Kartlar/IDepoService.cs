using FinalProject.Erp.Business.Abstract.Base;
using FinalProject.Erp.Model.Dtos.Kartlar;
using FinalProject.Erp.Model.Entities.Kartlar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FinalProject.Erp.Business.Abstract.Kartlar
{
    public interface IDepoService : IBaseService<Depo>
    {
        DepoEditDto GetDto(Expression<Func<Depo, bool>> filter);
        IEnumerable<DepoListDto> GetAllDto(Expression<Func<Depo, bool>> filter = null, Func<IQueryable<Depo>, IOrderedQueryable<Depo>> orderBy = null);
    }
}