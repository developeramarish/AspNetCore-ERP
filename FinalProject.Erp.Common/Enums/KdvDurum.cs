using System.ComponentModel;

namespace FinalProject.Erp.Common.Enums
{
    public enum KdvDurum : byte
    {
        [Description("Kdv Hariç")]
        KdvHaric = 1,
        [Description("Kdv Dahil")]
        KdvDahil = 2
    }
}