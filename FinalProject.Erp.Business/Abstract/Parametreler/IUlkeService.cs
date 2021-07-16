using FinalProject.Erp.Business.Abstract.Base;
using FinalProject.Erp.Model.Entities.Parametreler;
using System.Collections.Generic;

namespace FinalProject.Erp.Business.Abstract.Parametreler
{
    public interface IUlkeService : IBaseService<Ulke>
    {
        List<Ulke> GetAllByActiveCars(bool durum);
    }
}