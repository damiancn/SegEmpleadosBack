
namespace Entities.Models.Catalog
{
    using Entities.Models.Security;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("Employees", Schema = "Catalogs")]
    public class EmployeeModel
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
        public DateTime DateAcces { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public int Age { get; set; }
        [Column(TypeName = "text")]
        public string Fotography { get; set; }
        [MaxLength(50)]
        [Required]
        public string Position { get; set; }
        [Column(TypeName = "Decimal(8,2)")]
        [Required]
        public decimal Salary { get; set; }

        public List<BeneficiaryModel> Beneficiary { get; set; }
        public UserModel User { get; set; }
    }
}
