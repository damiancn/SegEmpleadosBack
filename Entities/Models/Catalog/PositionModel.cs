namespace Entities.Models.Catalog
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Positions", Schema = "Catalogs")]
    public class PositionModel
    {
        public Guid Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}
