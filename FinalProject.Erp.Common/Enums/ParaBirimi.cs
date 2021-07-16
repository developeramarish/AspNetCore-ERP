using System;
using System.ComponentModel;

namespace FinalProject.Erp.Common.Enums
{
    public enum ParaBirimi : Byte
    {
        [Description("TRY")]
        TRY = 1,
        [Description("USD")]
        USD = 2,
        [Description("EUR")]
        EUR = 3
    }
}