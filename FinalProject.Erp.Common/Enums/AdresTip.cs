using System;
using System.ComponentModel;

namespace FinalProject.Erp.Common.Enums
{
    public enum AdresTip : Byte
    {
        [Description("Fatura Adresi")]
        FaturaAdresi = 1,
        [Description("SevkAdresi")]
        SevkAdresi = 2,
        [Description("Diğer")]
        Diger = 3
    }
}