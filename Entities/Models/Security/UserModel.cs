
namespace Entities.Models.Security
{
    using Entities.Models.Catalog;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Users", Schema = "Security")]
    public class UserModel
    {
        public Guid Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }
        public bool Active { get; set; }
        public Guid? Fk_Employee { get; set; }

        // Propiedad de navegación
        [ForeignKey("Fk_Employee")]
        public EmployeeModel Employee { get; set; }
    }
}
