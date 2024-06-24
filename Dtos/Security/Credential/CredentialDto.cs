using Dtos.Security.Menu;
using Dtos.Security.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Security.Credential
{
    public class CredentialDto
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public Guid RolId { get; set; }
        public string Rol { get; set; }
        public List<PageDto> Pages { get; set; }
    }
}
