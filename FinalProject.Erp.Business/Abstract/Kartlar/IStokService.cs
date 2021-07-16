using FinalProject.Erp.Business.Abstract.Base;
using FinalProject.Erp.Model.Dtos.Kartlar;
using FinalProject.Erp.Model.Entities.Kartlar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FinalProject.Erp.Business.Abstract.Kartlar
{
    public interface IStokService : IBaseService<Stok>
    {
        StokEditDto GetDto(Expression<Func<Stok, bool>> filter);
        IEnumerable<StokListDto> GetAllDto(Expression<Func<Stok, bool>> filter = null, Func<IQueryable<Stok>, IOrderedQueryable<Stok>> orderBy = null);
    }
}