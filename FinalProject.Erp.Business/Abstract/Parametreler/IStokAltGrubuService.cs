using FinalProject.Erp.Business.Abstract.Base;
using FinalProject.Erp.Model.Entities.Parametreler;
using System.Collections.Generic;

namespace FinalProject.Erp.Business.Abstract.Parametreler
{
    public interface IStokAltGrubuService : IBaseService<StokAltGrubu>
    {
        List<StokAltGrubu> GetAllByActiveCars(int stokGrubuId, bool durum);
    }
}