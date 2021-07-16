using FinalProject.Erp.Business.Abstract.Base;
using FinalProject.Erp.Model.Dtos.Kartlar;
using FinalProject.Erp.Model.Entities.Kartlar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FinalProject.Erp.Business.Abstract.Kartlar
{
    public interface IKasaService : IBaseService<Kasa>
    {
        KasaEditDto GetDto(Expression<Func<Kasa, bool>> filter);
        IEnumerable<KasaListDto> GetAllDto(Expression<Func<Kasa, bool>> filter = null, Func<IQueryable<Kasa>, IOrderedQueryable<Kasa>> orderBy = null);
    }
}