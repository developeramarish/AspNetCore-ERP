using System.ComponentModel;

namespace FinalProject.Erp.Common.Enums
{
    public enum DekontTip : byte
    {
        [Description("Borç Dekontu")]
        BorcDekontu = 9,
        [Description("Alacak Dekontu")]
        AlacakDekontu = 10
    }
}