namespace Dtos.Security.User
{
    public class UserDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public Guid Fk_Employee { get; set; }
        public string EmployeeName { get; set; }
    }
}
