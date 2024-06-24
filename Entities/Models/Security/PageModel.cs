

namespace Entities.Models.Security
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Pages", Schema = "Security")]
    public class PageModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [MaxLength(20)]
        public string Icon { get; set; }
        [MaxLength(20)]
        public string Code { get; set; }
        [MaxLength(50)]
        public bool Active { get; set; }
    }
}
