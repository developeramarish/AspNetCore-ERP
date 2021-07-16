using FinalProject.Erp.Business.Abstract.Base;
using FinalProject.Erp.Model.Entities.Parametreler;
using System.Collections.Generic;

namespace FinalProject.Erp.Business.Abstract.Parametreler
{
    public interface IStokTurService : IBaseService<StokTur>
    {
        List<StokTur> GetAllByActiveCars(bool durum);
    }
}