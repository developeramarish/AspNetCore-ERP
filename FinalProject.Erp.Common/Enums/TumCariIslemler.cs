using System.ComponentModel;

namespace FinalProject.Erp.Common.Enums
{
    public enum TumCariIslemler : byte
    {
        [Description("")]
        IslemYok = 0,
        [Description("Banka Tahsilat (Gelen Havale)")]
        GelenHavale = 1,
        [Description("Banka Ödeme (Giden Havale)")]
        GidenHavale = 2,
        [Description("Nakit Tahsilat")]
        NakitTahsilat = 6,
        [Description("Nakit Ödeme")]
        NakitOdeme = 7,
        [Description("Cari Borç Dekontu")]
        BorcDekontu = 9,
        [Description("Cari Alacak Dekontu")]
        AlacakDekontu = 10,
        [Description("Cari Transfer (Virman)")]
        CariTransfer = 11
    }
}