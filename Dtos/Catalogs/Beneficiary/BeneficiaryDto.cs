using System.Diagnostics.CodeAnalysis;

namespace Dtos.Beneficiary
{
    public class BeneficiaryDto
    {
        [AllowNull]
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string SeconLastName { get; set; }
        public string Relationship { get; set; }
        public Guid Fk_Employee { get; set; }
        public string EmployeeName { get; set; }
    }
}
