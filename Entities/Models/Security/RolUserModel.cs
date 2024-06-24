
namespace Entities.Models.Security
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("RolUsers", Schema = "Security")]
    public class RolUserModel
    {
        public Guid Fk_Rol { get; set; }
        public Guid Fk_User { get; set; }

        [ForeignKey("Fk_Rol")]
        public RolModel Rol { get; set; }
        [ForeignKey("Fk_User")]
        public UserModel User { get; set; }
        public bool Active { get; set; }
    }
}
