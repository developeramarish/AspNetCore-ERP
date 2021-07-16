using System.ComponentModel;

namespace FinalProject.Erp.Common.Enums
{
    public enum HavaleTip : byte
    {
        [Description("Gelen Havale")]
        GelenHavale = 1,
        [Description("Giden Havale")]
        GidenHavale = 2
    }
}