using System.ComponentModel;

namespace FinalProject.Erp.Common.Enums
{
    public enum CariTipi : byte
    {
        [Description("MÜŞTERİ")]
        Musteri = 1,
        [Description("TEDARİKÇİ")]
        Tedarikci = 2,
        [Description("TEDARİKÇİ/MÜŞTERİ")]
        MusteriTedarikci = 3
    }
}