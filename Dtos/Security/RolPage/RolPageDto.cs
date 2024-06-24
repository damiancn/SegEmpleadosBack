using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Security.RolPage
{
    public class RolPageDto
    {
        public Guid Id { get; set; }
        public Guid Fk_Rol { get; set; }
        public string RolName { get; set; }
        public string PageName { get; set; }
        public bool Active { get; set; }
    }
}
