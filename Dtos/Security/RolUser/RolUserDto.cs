using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Security.RolUser
{
    public class RolUserDto
    {
        public Guid Fk_Rol { get; set; }
        public string RolName { get; set; }
        public Guid Fk_Usuario { get; set; }
        public string UserName { get; set; }
        public bool Active { get; set; }
    }
}
