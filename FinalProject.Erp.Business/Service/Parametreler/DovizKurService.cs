using FinalProject.Erp.Business.Abstract.Parametreler;
using FinalProject.Erp.Common.Enums;
using FinalProject.Erp.Core.Abstract.UnitOfWork;
using FinalProject.Erp.Model.Entities.Parametreler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Xml;

namespace FinalProject.Erp.Business.Service.Parametreler
{
    public class DovizKurService : IDovizKurService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DovizKurService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Any(Expression<Func<DovizKur, bool>> filter)
        {
            return _unitOfWork.GetRepository<DovizKur>().Any(filter);
        }

        public int Count(Expression<Func<DovizKur, bool>> filter = null)
        {
            return _unitOfWork.GetRepository<DovizKur>().Count(filter);
        }

        public void Delete(int id)
        {
            _unitOfWork.GetRepository<DovizKur>().Delete(id);
        }

        public void Delete(DovizKur entity)
        {
            _unitOfWork.GetRepository<DovizKur>().Delete(entity);
        }

        public void Delete(Expression<Func<DovizKur, bool>> filter)
        {
            _unitOfWork.GetRepository<DovizKur>().Delete(filter);
        }

        public DovizKur Get(Expression<Func<DovizKur, bool>> filter)
        {
            return _unitOfWork.GetRepository<DovizKur>().Get(filter);
        }

        public IEnumerable<DovizKur> GetAll(Expression<Func<DovizKur, bool>> filter = null, Func<IQueryable<DovizKur>, IOrderedQueryable<DovizKur>> orderBy = null)
        {
            return _unitOfWork.GetRepository<DovizKur>().GetAll(filter, orderBy);
        }

        public DovizKur GetById(int id)
        {
            return _unitOfWork.GetRepository<DovizKur>().GetById(id);
        }

        public bool Insert(DovizKur entity)
        {
            _unitOfWork.GetRepository<DovizKur>().Insert(entity);
            return true;
        }

        public bool Update(DovizKur entity)
        {
            _unitOfWork.GetRepository<DovizKur>().Update(entity);
            return true;
        }

        public string NewCode(KartTuru kartTuru, Expression<Func<DovizKur, string>> filter, Expression<Func<DovizKur, bool>> where = null)
        {
            return _unitOfWork.GetRepository<DovizKur>().NewCode(kartTuru, filter, where);
        }

        public void RecordHide(int id, bool hide)
        {
            _unitOfWork.GetRepository<DovizKur>().RecordHide(id, hide);
        }

        public List<DovizKur> GetAllCurrenciesTodaysExchangeRates()
        {
            List<DovizKur> data = GetAll(a => a.Tarih == DateTime.Today).ToList();

            if (data.Count > 0)
            {
                return data;
            }

            Dictionary<string, DovizKur> CurrencyRates = GetCurrencyRates("http://www.tcmb.gov.tr/kurlar/today.xml");
            List<DovizKur> dovizKurs = new List<DovizKur>();

            foreach (string item in CurrencyRates.Keys)
            {
                DovizKur dovizKur = new DovizKur
                {
                    Tarih = CurrencyRates[item].Tarih,
                    DovizKodu = CurrencyRates[item].DovizKodu,
                    DovizCinsi = CurrencyRates[item].DovizCinsi,
                    Birim = CurrencyRates[item].Birim,
                    DovizAlis = CurrencyRates[item].DovizAlis,
                    DovizSatis = CurrencyRates[item].DovizSatis,
                    EfektifAlis = CurrencyRates[item].EfektifAlis,
                    EfektifSatis = CurrencyRates[item].EfektifSatis,
                };

                Insert(dovizKur);
                _unitOfWork.SaveChanges();

                dovizKurs.Add(dovizKur);
            }

            return dovizKurs;
        }

        public List<DovizKur> GetDataTableAllCurrenciesHistoricalExchangeRates(int Year, int Month, int Day)
        {
            string SYear = String.Format("{0:0000}", Year);
            string SMonth = String.Format("{0:00}", Month);
            string SDay = String.Format("{0:00}", Day);

            Dictionary<string, DovizKur> CurrencyRates = GetCurrencyRates("http://www.tcmb.gov.tr/kurlar/" + SYear + SMonth + "/" + SDay + SMonth + SYear + ".xml");
            List<DovizKur> dovizKurs = new List<DovizKur>();

            foreach (string item in CurrencyRates.Keys)
            {
                DovizKur dovizKur = new DovizKur
                {
                    Tarih = CurrencyRates[item].Tarih,
                    DovizKodu = CurrencyRates[item].DovizKodu,
                    DovizCinsi = CurrencyRates[item].DovizCinsi,
                    Birim = CurrencyRates[item].Birim,
                    DovizAlis = CurrencyRates[item].DovizAlis,
                    DovizSatis = CurrencyRates[item].DovizSatis,
                    EfektifAlis = CurrencyRates[item].EfektifAlis,
                    EfektifSatis = CurrencyRates[item].EfektifSatis,
                };

                dovizKurs.Add(dovizKur);
            }

            return dovizKurs;
        }

        public Dictionary<string, DovizKur> GetCurrencyRates(string Link)
        {
            XmlTextReader rdr = new XmlTextReader(Link);
            XmlDocument myxml = new XmlDocument();
            myxml.Load(rdr);

            XmlNode tarih = myxml.SelectSingleNode("/Tarih_Date/@Tarih");
            XmlNodeList adi = myxml.SelectNodes("/Tarih_Date/Currency/Isim");
            XmlNodeList kod = myxml.SelectNodes("/Tarih_Date/Currency/@Kod");
            XmlNodeList birim = myxml.SelectNodes("/Tarih_Date/Currency/Unit");
            XmlNodeList doviz_alis = myxml.SelectNodes("/Tarih_Date/Currency/ForexBuying");
            XmlNodeList doviz_satis = myxml.SelectNodes("/Tarih_Date/Currency/ForexSelling");
            XmlNodeList efektif_alis = myxml.SelectNodes("/Tarih_Date/Currency/BanknoteBuying");
            XmlNodeList efektif_satis = myxml.SelectNodes("/Tarih_Date/Currency/BanknoteSelling");

            Dictionary<string, DovizKur> ExchangeRates = new Dictionary<string, DovizKur>();

            for (int i = 0; i < adi.Count; i++)
            {
                DovizKur cur = new DovizKur
                {
                    Tarih = Convert.ToDateTime(tarih.InnerText.ToString()),
                    DovizKodu = kod.Item(i).InnerText.ToString(),
                    DovizCinsi = adi.Item(i).InnerText.ToString(),
                    Birim = Convert.ToInt16(birim.Item(i).InnerText.ToString()),
                    DovizAlis = (String.IsNullOrWhiteSpace(doviz_alis.Item(i).InnerText.ToString())) ? 0 : Convert.ToDecimal(doviz_alis.Item(i).InnerText.ToString().Replace(".", ",")),
                    DovizSatis = (String.IsNullOrWhiteSpace(doviz_satis.Item(i).InnerText.ToString())) ? 0 : Convert.ToDecimal(doviz_satis.Item(i).InnerText.ToString().Replace(".", ",")),
                    EfektifAlis = (String.IsNullOrWhiteSpace(efektif_alis.Item(i).InnerText.ToString())) ? 0 : Convert.ToDecimal(efektif_alis.Item(i).InnerText.ToString().Replace(".", ",")),
                    EfektifSatis = (String.IsNullOrWhiteSpace(efektif_satis.Item(i).InnerText.ToString())) ? 0 : Convert.ToDecimal(efektif_satis.Item(i).InnerText.ToString().Replace(".", ","))
                };

                ExchangeRates.Add(kod.Item(i).InnerText.ToString(), cur);
            }

            return ExchangeRates;
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }
    }
}