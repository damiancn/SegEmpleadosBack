
namespace Entities.Models.Security
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("RolPages", Schema = "Security")]
    public class RolPageModel
    {
        public Guid Id { get; set; }
        public Guid Fk_Rol { get; set; }
        public Guid Fk_Pagina { get; set; }
        public bool Active { get; set; }
        [ForeignKey("Fk_Pagina")]
        public virtual PageModel Page { get; set; }
        [ForeignKey("Fk_Rol")]
        public virtual RolModel Rol { get; set; }

    }
}
