using System.ComponentModel;

namespace FinalProject.Erp.Common.Enums
{
    public enum BankaKasaIslem : byte
    {
        [Description("BANKAYA PARA YATIRMA")]
        BankayaParaYatirma = 3,
        [Description("BANKADAN PARA ÇEKME")]
        BankadanParaCekme = 4
    }
}