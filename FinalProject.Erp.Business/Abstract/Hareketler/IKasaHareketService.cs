using FinalProject.Erp.Business.Abstract.Base;
using FinalProject.Erp.Model.Dtos.Hareketler;
using FinalProject.Erp.Model.Entities.Hareketler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FinalProject.Erp.Business.Abstract.Hareketler
{
    public interface IKasaHareketService : IBaseService<KasaHareket>
    {
        KasaHareketEditDto GetDto(Expression<Func<KasaHareket, bool>> filter);
        IEnumerable<KasaHareketListDto> GetAllDto(Expression<Func<KasaHareket, bool>> filter = null, Func<IQueryable<KasaHareket>, IOrderedQueryable<KasaHareket>> orderBy = null);
    }
}