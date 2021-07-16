using FinalProject.Erp.Business.Abstract.Base;
using FinalProject.Erp.Model.Dtos.Hareketler;
using FinalProject.Erp.Model.Entities.Hareketler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FinalProject.Erp.Business.Abstract.Hareketler
{
    public interface IBankaHareketService : IBaseService<BankaHareket>
    {
        BankaHareketEditDto GetDto(Expression<Func<BankaHareket, bool>> filter);
        IEnumerable<BankaHareketListDto> GetAllDto(Expression<Func<BankaHareket, bool>> filter = null, Func<IQueryable<BankaHareket>, IOrderedQueryable<BankaHareket>> orderBy = null);
    }
}