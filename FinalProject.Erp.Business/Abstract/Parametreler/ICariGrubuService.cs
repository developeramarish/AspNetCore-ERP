using FinalProject.Erp.Business.Abstract.Base;
using FinalProject.Erp.Model.Entities.Parametreler;
using System.Collections.Generic;

namespace FinalProject.Erp.Business.Abstract.Parametreler
{
    public interface ICariGrubuService : IBaseService<CariGrubu>
    {
        List<CariGrubu> GetAllByActiveCars(bool durum);
    }
}