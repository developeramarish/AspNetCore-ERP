using System.ComponentModel;

namespace FinalProject.Erp.Common.Enums
{
    public enum TumKasaIslemler : byte
    {
        [Description("")]
        IslemYok = 0,
        [Description("Bankaya Para Yatırma")]
        BankayaParaYatirma = 3,
        [Description("Bankadan Para Çekme")]
        BankadanParaCekme = 4,
        [Description("Nakit Tahsilat")]
        NakitTahsilat = 6,
        [Description("Nakit Ödeme")]
        NakitOdeme = 7,
        [Description("Kasa Transfer (Virman)")]
        KasaTransfer = 8
    }
}