
namespace Dtos.Security.Rol
{
using System.ComponentModel.DataAnnotations;
    public class RolDto
    {
        public Guid Id { get; set; }
        [MaxLength(20)]
        public string Code { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}
