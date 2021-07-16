using FinalProject.Erp.Business.Abstract.Base;
using FinalProject.Erp.Model.Dtos.Kartlar;
using FinalProject.Erp.Model.Entities.Kartlar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FinalProject.Erp.Business.Abstract.Kartlar
{
    public interface ICariService : IBaseService<Cari>
    {
        CariEditDto GetDto(Expression<Func<Cari, bool>> filter);
        IEnumerable<CariListDto> GetAllDto(Expression<Func<Cari, bool>> filter = null, Func<IQueryable<Cari>, IOrderedQueryable<Cari>> orderBy = null);
    }
}