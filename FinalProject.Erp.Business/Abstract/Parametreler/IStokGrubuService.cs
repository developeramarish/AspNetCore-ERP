using FinalProject.Erp.Business.Abstract.Base;
using FinalProject.Erp.Model.Entities.Parametreler;
using System.Collections.Generic;

namespace FinalProject.Erp.Business.Abstract.Parametreler
{
    public interface IStokGrubuService : IBaseService<StokGrubu>
    {
        List<StokGrubu> GetAllByActiveCars(bool durum);
    }
}