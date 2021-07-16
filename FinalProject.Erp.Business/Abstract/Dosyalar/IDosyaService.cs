using System.Collections.Generic;

namespace FinalProject.Erp.Business.Abstract.Dosyalar
{
    public interface IDosyaService
    {
        byte[] AktarExcel<T>(List<T> list) where T : class, new();
        string AktarPdf<T>(List<T> list) where T : class, new();
    }
}