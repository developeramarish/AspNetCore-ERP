using System.ComponentModel;

namespace FinalProject.Erp.Common.Enums
{
    public enum CariKasaIslem : byte
    {
        [Description("NAKİT TAHSİLAT")]
        NakitTahsilat = 6,
        [Description("NAKİT ÖDEME")]
        NakitOdeme = 7
    }
}