
namespace Entities.Models.Security
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Roles", Schema = "Security")]
    public class RolModel
    {
        public Guid Id { get; set; }
        [MaxLength(20)]
        public string Code { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}
