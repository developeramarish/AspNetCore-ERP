using System.ComponentModel;

namespace FinalProject.Erp.Common.Enums
{
    public enum TumBankaIslemler : byte
    {
        [Description("")]
        IslemYok = 0,
        [Description("Gelen Havale")]
        GelenHavale = 1,
        [Description("Giden Havale")]
        GidenHavale = 2,
        [Description("Bankaya Para Yatırma")]
        BankayaParaYatirma = 3,
        [Description("Bankadan Para Çekme")]
        BankadanParaCekme = 4,
        [Description("Banka Transfer (Virman)")]
        BankaTransfer = 5
    }
}