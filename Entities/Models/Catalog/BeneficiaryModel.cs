

namespace Entities.Models.Catalog
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("Beneficiaries", Schema = "Catalogs")]
    public class BeneficiaryModel
    {
        public Guid Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        [MaxLength(100)]
        [Required]
        public string FirstName { get; set; }
        public string SeconLastName { get; set; }
        [Required]
        public string Relationship { get; set; }
        public Guid Fk_Employee { get; set; }

        [ForeignKey("Fk_Employee")]
        public EmployeeModel Employee { get; set; }

    }
}
