using System;
using System.ComponentModel;

namespace FinalProject.Erp.Common.Enums
{
    public enum KesintiTipi : Byte
    {
        [Description("Eşit Dağıt")]
        EsitDagit = 1,

        [Description("İlk Hareketten Düş")]
        IlkHarekettenDus = 2
    }
}