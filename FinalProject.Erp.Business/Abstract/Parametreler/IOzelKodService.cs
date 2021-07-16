using FinalProject.Erp.Business.Abstract.Base;
using FinalProject.Erp.Common.Enums;
using FinalProject.Erp.Model.Entities.Parametreler;
using System.Collections.Generic;

namespace FinalProject.Erp.Business.Abstract.Parametreler
{
    public interface IOzelKodService : IBaseService<OzelKod>
    {
        List<OzelKod> GetAllByActiveCars(bool durum, OzelKodKart kart, OzelKodSira sira);
    }
}