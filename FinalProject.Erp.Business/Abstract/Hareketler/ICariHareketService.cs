using FinalProject.Erp.Business.Abstract.Base;
using FinalProject.Erp.Model.Dtos.Hareketler;
using FinalProject.Erp.Model.Entities.Hareketler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FinalProject.Erp.Business.Abstract.Hareketler
{
    public interface ICariHareketService : IBaseService<CariHareket>
    {
        CariHareketEditDto GetDto(Expression<Func<CariHareket, bool>> filter);
        IEnumerable<CariHareketListDto> GetAllDto(Expression<Func<CariHareket, bool>> filter = null, Func<IQueryable<CariHareket>, IOrderedQueryable<CariHareket>> orderBy = null);
    }
}