using System;
using System.ComponentModel;

namespace FinalProject.Erp.Common.Enums
{
    public enum OdemeSekli : Byte
    {
        [Description("Peşin")]
        Pesin = 1,
        [Description("Vadeli")]
        Vadeli = 2
    }
}
