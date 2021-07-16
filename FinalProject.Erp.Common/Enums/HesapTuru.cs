using System;
using System.ComponentModel;

namespace FinalProject.Erp.Common.Enums
{
    public enum HesapTuru : Byte
    {
        [Description("Vadesiz Hesap")]
        Vadesiz = 1,

        [Description("Vadeli Hesap")]
        Vadeli = 2
    }
}