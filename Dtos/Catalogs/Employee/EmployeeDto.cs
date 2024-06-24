using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Employee
{
    public class EmployeeDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string SeconLastName { get; set; }
        public string FullName { get; set; }
        public DateTime DateAcces { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public string Fotography { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
    }
}
