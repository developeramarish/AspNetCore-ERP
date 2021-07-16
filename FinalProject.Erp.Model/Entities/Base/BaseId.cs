using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Erp.Model.Entities.Base
{
    public abstract class BaseId
    {
        [Column(Order = 1)]
        public int Id { get; set; }
    }
}