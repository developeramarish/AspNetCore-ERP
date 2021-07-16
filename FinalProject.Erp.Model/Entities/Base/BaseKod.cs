using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Erp.Model.Entities.Base
{
    public abstract class BaseKod : BaseId
    {
        [Column(Order = 2)]
        public string Kod { get; set; }
    }
}