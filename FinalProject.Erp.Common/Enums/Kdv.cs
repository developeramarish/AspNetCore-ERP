using System;
using System.ComponentModel;

namespace FinalProject.Erp.Common.Enums
{
    public enum Kdv : Byte
    {
        [Description("0")]
        Sifir = 0,
        [Description("1")]
        Bir = 1,
        [Description("8")]
        Sekiz = 8,
        [Description("18")]
        OnSekiz = 18,
        [Description("25")]
        YirmiBes = 25
    }
}