using FinalProject.Erp.Business.Abstract.Base;
using FinalProject.Erp.Model.Entities.Parametreler;
using System.Collections.Generic;

namespace FinalProject.Erp.Business.Abstract.Parametreler
{
    public interface IDovizKurService : IBaseService<DovizKur>
    {
        List<DovizKur> GetAllCurrenciesTodaysExchangeRates();
        List<DovizKur> GetDataTableAllCurrenciesHistoricalExchangeRates(int Year, int Month, int Day);
        Dictionary<string, DovizKur> GetCurrencyRates(string Link);
    }
}