using System;
using System.ComponentModel;

namespace FinalProject.Erp.Common.Enums
{
    public enum KartTuru : Byte
    {
        /*Parametreler*/
        [Description("BIRIM ")]
        Birim = 1,
        [Description("CARIGRUP ")]
        CariGrubu = 2,
        [Description("CARIALTGRUP ")]
        CariAltGrubu = 3,
        [Description("HAREKETGRUP ")]
        HareketGrubu = 4,
        [Description("HAREKETALTGRUP ")]
        HareketAltGrubu = 5,
        [Description("SEHIR ")]
        Sehir = 6,
        [Description("ILCE ")]
        Ilce = 7,
        [Description("MARKA ")]
        Marka = 8,
        [Description("MODEL ")]
        Model = 9,
        [Description("OZELKOD ")]
        OzelKod = 10,
        [Description("PERSONELGOREV ")]
        PersonelGorev = 11,
        [Description("STOKGRUP ")]
        StokGrubu = 12,
        [Description("STOKALTGRUP ")]
        StokAltGrubu = 13,
        [Description("STOKTUR ")]
        StokTur = 14,
        [Description("ULKE ")]
        Ulke = 15,
        [Description("DEPARTMAN ")]
        Departman = 16,
        [Description("DOVIZ ")]
        DovizKur = 17,

        /*Kartlar*/
        [Description("BANKA ")]
        Banka = 18,
        [Description("CARI ")]
        Cari = 19,
        [Description("CARINOT ")]
        CariNot = 20,
        [Description("DEPO ")]
        Depo = 21,
        [Description("KASA ")]
        Kasa = 22,
        [Description("STOK ")]
        Stok = 23,

        /*Hareketler*/
        [Description("BANKAHRK ")]
        BankaHareket = 24,
        [Description("CARIHRK ")]
        CariHareket = 25,
        [Description("KASAHRK ")]
        KasaHareket = 26
    }
}