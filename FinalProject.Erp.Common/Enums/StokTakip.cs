using System.ComponentModel;

namespace FinalProject.Erp.Common.Enums
{
    public enum StokTakip : byte
    {
        [Description("Takip Yok")]
        TakipYok = 1,
        [Description("Seri Takip")]
        SeriTakip = 2,
        [Description("Lot Takip")]
        LotTakip = 3
    }
}